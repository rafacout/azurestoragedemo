﻿using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Collections;

namespace queue_receive
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

            _queue.FetchAttributes();
            int? _count = _queue.ApproximateMessageCount;

            for (int i = 0; i < _count; i++)
            {
                CloudQueueMessage _message = _queue.GetMessage();
                Console.WriteLine(_message.AsString);
                _queue.DeleteMessage(_message);
            }
            Console.ReadLine();
        }
        
    }
}
