import http from 'http';
import WebSocket from 'ws';

// Create an HTTP server
const server = http.createServer((req, res) => {
  res.writeHead(200, { 'Content-Type': 'text/plain' });
  res.end('WebSocket server is running');
});

// Create a WebSocket server by passing the HTTP server as an argument
const wss = new WebSocket.Server({ server });

// Define the WebSocket connection event
wss.on('connection', (ws) => {
  console.log('Client connected');

  // Send a message to the client when a connection is established
  ws.send('Welcome to the WebSocket server');

  // Handle incoming messages from the client
  ws.on('message', (message) => {
    console.log(`Received message: ${message}`);

    // Echo the received message back to the client
    ws.send(`You sent: ${message}`);
  });

  // Handle disconnection
  ws.on('close', () => {
    console.log('Client disconnected');
  });
});

// Start the HTTP server and WebSocket server
const PORT = process.env.PORT || 3000;
server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
