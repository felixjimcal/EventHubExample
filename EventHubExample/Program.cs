using Microsoft.Azure.EventHubs;
using System.Text;

namespace EventHubExample
{
    public class Program
    {
        private static EventHubClient? eventHubClient;
        private const string EventHubConnectionString = "Endpoint=sb://fleurtopics.servicebus.windows.net/;SharedAccessKeyName=helloworld;SharedAccessKey=o9yumZB1X8USCQhcA/HNV7GTVxgmfEPYX+AEhIciafg=;EntityPath=holiday";
        private const string EventHubName = "holiday";

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but for the sake of this simple scenario
            // we are using the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub();

            await eventHubClient.CloseAsync();
        }

        // Creates an event hub client and sends 100 messages to the event hub.
        private static async Task SendMessagesToEventHub()
        {
            int i = 0;
            while (true)
            {
                try
                {
                    var message = $"HelloWorld {i}";
                    Console.WriteLine($"Sending message: {message}");
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                    i++;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                await Task.Delay(10);
            }
        }
    }
}