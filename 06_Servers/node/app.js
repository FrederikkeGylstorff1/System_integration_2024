import express from "express";

const app = express();


app.get("/", (req, res) => {
    res.send({ message: "hallo" });

});

app.get("/otherRoute", (req, res) => {
    res.send({ massage: "this is another route" });

});

app.post("/postrquest", (req, res) => {
    res.send({message: "sdf"})
});


const PORT= 8080
app.listen(PORT, () => console.log("server is runing on port", PORT));