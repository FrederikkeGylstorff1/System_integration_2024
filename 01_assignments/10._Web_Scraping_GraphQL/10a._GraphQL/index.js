// index.js
const { ApolloServer } = require('@apollo/server');
const { startStandaloneServer } = require('@apollo/server/standalone');
const { makeExecutableSchema } = require('@graphql-tools/schema');
const { PubSub } = require('graphql-subscriptions');
const { v4: uuidv4 } = require('uuid');

const pubsub = new PubSub();
const BOOK_ADDED = 'BOOK_ADDED';

// Load the schema
const fs = require('fs');
const path = require('path');
const typeDefs = fs.readFileSync(path.join(__dirname, 'schema.graphql'), 'utf8');

// Sample data
let authors = [
  { id: '1', name: 'Author One' },
  { id: '2', name: 'Author Two' }
];

let books = [
  { id: '1', title: 'Book One', releaseYear: 2001, authorId: '1' },
  { id: '2', title: 'Book Two', releaseYear: 2002, authorId: '2' }
];

// Resolvers
const resolvers = {
  Query: {
    books: () => books,
    book: (_, { id }) => books.find(book => book.id === id),
    authors: () => authors,
    author: (_, { id }) => authors.find(author => author.id === id),
  },
  Mutation: {
    createBook: (_, { authorId, title, releaseYear }) => {
      const book = { id: uuidv4(), authorId, title, releaseYear };
      books.push(book);
      pubsub.publish(BOOK_ADDED, { bookAdded: book });
      return book;
    },
    updateBook: (_, { id, authorId, title, releaseYear }) => {
      let book = books.find(book => book.id === id);
      if (!book) throw new Error('Book not found');
      if (authorId !== undefined) book.authorId = authorId;
      if (title !== undefined) book.title = title;
      if (releaseYear !== undefined) book.releaseYear = releaseYear;
      return book;
    },
    deleteBook: (_, { id }) => {
      books = books.filter(book => book.id !== id);
      return { message: 'Book deleted successfully' };
    }
  },
  Subscription: {
    bookAdded: {
      subscribe: () => pubsub.asyncIterator([BOOK_ADDED])
    }
  },
  Book: {
    author: (book) => authors.find(author => author.id === book.authorId)
  },
  Author: {
    books: (author) => books.filter(book => book.authorId === author.id)
  }
};

// Create the schema
const schema = makeExecutableSchema({ typeDefs, resolvers });

// Start the server
const server = new ApolloServer({ schema });

startStandaloneServer(server, {
  listen: { port: 4000 },
}).then(({ url }) => {
  console.log(`🚀 Server ready at ${url}`);
});
