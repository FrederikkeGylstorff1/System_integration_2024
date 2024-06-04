import express from 'express';
import bodyParser from 'body-parser';
import sqlite3 from 'sqlite3';

const app = express();
const db = new sqlite3.Database(':memory:');

app.use(bodyParser.json());

// Initialize database
db.serialize(() => {
    db.run(`CREATE TABLE IF NOT EXISTS webhooks (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        event_type TEXT NOT NULL,
        callback_url TEXT NOT NULL
    )`);
});

// Register webhook
app.post('/register', (req, res) => {
    const { event_type, callback_url } = req.body;
    if (!event_type || !callback_url) {
        return res.status(400).json({ error: 'Invalid data' });
    }
    
    db.run('INSERT INTO webhooks (event_type, callback_url) VALUES (?, ?)', [event_type, callback_url], (err) => {
        if (err) {
            return res.status(500).json({ error: 'Database error' });
        }
        res.json({ message: 'Webhook registered successfully' });
    });
});

// Unregister webhook
app.post('/unregister', (req, res) => {
    const { event_type, callback_url } = req.body;
    if (!event_type || !callback_url) {
        return res.status(400).json({ error: 'Invalid data' });
    }
    
    db.run('DELETE FROM webhooks WHERE event_type = ? AND callback_url = ?', [event_type, callback_url], (err) => {
        if (err) {
            return res.status(500).json({ error: 'Database error' });
        }
        res.json({ message: 'Webhook unregistered successfully' });
    });
});

// Ping
app.post('/ping', (req, res) => {
    db.all('SELECT callback_url FROM webhooks', [], (err, rows) => {
        if (err) {
            return res.status(500).json({ error: 'Database error' });
        }

        rows.forEach((row) => {
            console.log(`Sending ping event to ${row.callback_url}`);
        });

        res.json({ message: 'Ping events sent to all registered webhooks' });
    });
});

// Start server
const PORT = 3000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
