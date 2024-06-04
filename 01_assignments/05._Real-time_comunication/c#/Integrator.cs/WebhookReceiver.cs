using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class WebhookReceiver
{
    public static void StartServer()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:5000/"); // Lyt til root URL
        listener.Start();
        Console.WriteLine("Listening for webhooks at http://localhost:5000/webhook-handler/");

        Task.Run(() =>
        {
            while (true)
            {
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                if (request.Url.AbsolutePath == "/register-webhook" && request.HttpMethod == "POST")
                {
                    RegisterWebhook().Wait();
                    response.StatusCode = 200;
                    using (var writer = new System.IO.StreamWriter(response.OutputStream))
                    {
                        writer.Write("Webhook registered successfully");
                    }
                }
                else if (request.Url.AbsolutePath == "/webhook-handler" && request.HttpMethod == "POST")
                {
                    using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        var json = reader.ReadToEnd();
                        Console.WriteLine($"Received webhook: {json}");
                    }

                    response.StatusCode = 200;
                }
                else if (request.Url.AbsolutePath == "/unregister-webhook" && request.HttpMethod == "POST")
                {
                    UnregisterWebhook().Wait();
                    response.StatusCode = 200;
                    using (var writer = new System.IO.StreamWriter(response.OutputStream))
                    {
                        writer.Write("Webhook unregistered successfully");
                    }
                }
                else
                {
                    response.StatusCode = 404;
                    using (var writer = new System.IO.StreamWriter(response.OutputStream))
                    {
                        writer.Write("Not found");
                    }
                }

                response.Close();
            }
        });
    }

    public static async Task RegisterWebhook()
    {
        var endpoint = "http://localhost:3000/register"; // Exposee endpoint

        var webhookData = new
        {
            eventType = "payment_received",
            endpoint = "http://localhost:5000/webhook-handler" // Integrator webhook handler endpoint
        };

        using (var httpClient = new HttpClient())
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(webhookData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Webhook registered successfully");
            }
            else
            {
                Console.WriteLine($"Failed to register webhook: {response.ReasonPhrase}");
            }
        }
    }

    public static async Task UnregisterWebhook()
    {
        var endpoint = "http://localhost:3000/unregister"; // Exposee endpoint

        var webhookData = new
        {
            endpoint = "http://localhost:5000/webhook-handler" // Integrator webhook handler endpoint
        };

        using (var httpClient = new HttpClient())
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(webhookData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Webhook unregistered successfully");
            }
            else
            {
                Console.WriteLine($"Failed to unregister webhook: {response.ReasonPhrase}");
            }
        }
    }
}
