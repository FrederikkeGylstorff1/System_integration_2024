using System;

class Program
{
    static void Main(string[] args)
    {
        // Start the webhook receiver server
        WebhookReceiver.StartServer();

        // Keep the console open
        Console.WriteLine("Server is running. Press Enter to exit...");
        Console.ReadLine();
    }
}
