
import express from 'express';
import bodyParser from 'body-parser';

const app = express();
app.use(bodyParser.json());

app.post('/webhook', (req, res) => {
    console.log('Received webhook event:', req.body);
    res.sendStatus(200);
});

const PORT = 3001;
app.listen(PORT, () => {
    console.log(`Webhook receiver is running on port ${PORT}`);
});
