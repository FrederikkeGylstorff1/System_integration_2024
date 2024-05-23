// Integrator.cs

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var endpoint = "http://localhost:3000/register"; // Change this to the exposee endpoint

        // Sample webhook registration data
        var webhookData = new
        {
            eventType = "payment_received",
            endpoint = "http://integrator.com/webhook-handler" // Change this to your webhook handler endpoint
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
}
