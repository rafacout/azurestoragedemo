using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace queue_send
{
    class Program
    {
        private static string queue_connection_string = "DefaultEndpointsProtocol=https;AccountName=storagedemo1001;AccountKey=YQVKvjLgVPz6EgjjXkLvdCO0lC2a8yRgbMk1rBZdVuMaCTJCzdZbNO/DIumQs6svOuLs/KsPt6vIlSl1cXtE7w==;EndpointSuffix=core.windows.net";
        private static string queue_name = "app";
        static void Main(string[] args)
        {
            
            CloudStorageAccount queue_acc = CloudStorageAccount.Parse(queue_connection_string);
            
            CloudQueueClient queue_client = queue_acc.CreateCloudQueueClient();
            
            CloudQueue _queue = queue_client.GetQueueReference(queue_name);

            for (int i = 1; i < 10; i++)
            {
                Order obj = new Order();
                CloudQueueMessage _message = new CloudQueueMessage(obj.ToString());
                _queue.AddMessage(_message);
            }

            Console.WriteLine("All messages sent");
            Console.ReadLine();


        }
    }
}
