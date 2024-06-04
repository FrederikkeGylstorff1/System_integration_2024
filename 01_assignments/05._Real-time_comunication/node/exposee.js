import express from 'express';
import bodyParser from 'body-parser';
import fetch from 'node-fetch'; // Sørg for, at node-fetch er installeret

const app = express();
app.use(bodyParser.json());

let webhooks = [];

app.post('/register', (req, res) => {
    const { eventType, endpoint } = req.body;
    webhooks.push({ eventType, endpoint });
    res.status(200).send('Webhook registered successfully');
});

app.delete('/unregister', (req, res) => {
    const { endpoint } = req.body;
    webhooks = webhooks.filter(webhook => webhook.endpoint !== endpoint);
    res.status(200).send('Webhook unregistered successfully');
});

app.get('/ping', (req, res) => {
    webhooks.forEach(webhook => {
        console.log(`Calling webhook: ${webhook.endpoint} for event: ${webhook.eventType}`);
        fetch(webhook.endpoint, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ eventType: webhook.eventType, data: "Ping test" })
        }).catch(error => console.error(`Failed to call webhook: ${error.message}`));
    });
    res.status(200).send('Ping event triggered successfully');
});

const port = 3000;
app.listen(port, () => {
    console.log(`Exposee server listening at http://localhost:${port}`);
});
