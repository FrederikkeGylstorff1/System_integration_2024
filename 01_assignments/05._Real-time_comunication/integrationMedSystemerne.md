Webhook Registreringssystem
Endpoints

Registrer en Webhook
URL: /register
Metode: POST
Content-Type: application/json
Body Parametre:
eventType (string): Typen af hændelse (f.eks. "payment_received").
endpoint (string): URL'en til at modtage webhook-opkald.
Respons:
200 OK: Webhook registreret med succes.


Afregistrer en Webhook
URL: /unregister
Metode: DELETE
Content-Type: application/json
Body Parametre:
endpoint (string): URL'en på den webhook, der skal afregistreres.
Respons:
200 OK: Webhook afregistreret med succes.


Ping Hændelse
URL: /ping
Metode: GET
Respons:
200 OK: Ping hændelse udløst med succes.

Brug
Start serveren: node server.mjs
Brug endpoints til at registrere, afregistrere og pinge webhooks.