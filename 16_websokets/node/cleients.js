import {WebSocket} from "ws";

const webSocketClient = new WebSocket("ws://localhost:8080");

webSocketClient.on("open", () => {

    webSocketClient.send("message");

    

});