import express from 'express';
import bodyParser from 'body-parser';

const app = express();
app.use(bodyParser.json());

// Simple in-memory storage for registered webhooks
let webhooks = [];

// Endpoint to register a webhook
app.post('/register', (req, res) => {
    const { eventType, endpoint } = req.body;
    webhooks.push({ eventType, endpoint });
    res.status(200).send('Webhook registered successfully');
});

// Endpoint to unregister a webhook
app.delete('/unregister', (req, res) => {
    const { endpoint } = req.body;
    webhooks = webhooks.filter(webhook => webhook.endpoint !== endpoint);
    res.status(200).send('Webhook unregistered successfully');
});

// Endpoint to trigger all registered webhooks
app.get('/ping', (req, res) => {
    webhooks.forEach(webhook => {
        // Simulate calling the webhook endpoint
        console.log(`Calling webhook: ${webhook.endpoint} for event: ${webhook.eventType}`);
        // You would typically make an HTTP POST request to the webhook endpoint here
    });
    res.status(200).send('Ping event triggered successfully');
});

// Start the server
const port = 3000;
app.listen(port, () => {
    console.log(`Exposee server listening at http://localhost:${port}`);
});
