import axios from 'axios';

async function registerWebhook() {
    const url = 'http://localhost:3000/register';
    const data = {
        event_type: 'payment_received',
        callback_url: 'http://localhost:3001/webhook'
    };
    
    try {
        const response = await axios.post(url, data);
        console.log(response.data);
    } catch (error) {
        console.error('Error registering webhook:', error);
    }
}

registerWebhook();
