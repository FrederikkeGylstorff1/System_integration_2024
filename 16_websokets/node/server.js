import { WebSocket, WebSocketServer } from "ws";

const PORT = process.env.PORT ?? 8080;

const server = new WebSocketServer({port: PORT});

server.on("conection", (ws) => {
    console.log("New conection", server.cleints.size);


    ws.on("message", (message) => {
        console.log('meaage Reseved form client: ${}.');
    });
});