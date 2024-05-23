import { WebSocket, WebSocketServer } from "ws";


const server = new WebSocket.Server({ port: 8080 });

server.on('connection', function connection(ws) {
  ws.on('message', function incoming(message) {
    console.log('received from client: %s', message);
    ws.send('Message received by server: ' + message);
  });
});
