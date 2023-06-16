using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Get_Queue
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fila de mensagem");

            var client = new AmazonSQSClient(RegionEndpoint.USEast2);
            var request = new ReceiveMessageRequest
            {
                QueueUrl = "https://sqs.us-east-2.amazonaws.com/639036197223/architecture"
            };

            while (true)
            {
                var response = await client.ReceiveMessageAsync(request);

                foreach (var mensagem in response.Messages)
                {
                    Console.WriteLine(mensagem.Body);
                    await client.DeleteMessageAsync("https://sqs.us-east-2.amazonaws.com/639036197223/architecture", mensagem.ReceiptHandle);
                    Console.WriteLine("Mensagem Com id: "+ mensagem.MessageId + " Lida e Apagada");
                }
            }
        }
    }
}
