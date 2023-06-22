using ServiceStack;
using System.Text.Json;

namespace Result
{
    public class HttpStream<T> : IStream<T>
    {
        private readonly ServerEventsClient client;

        public HttpStream(string Url)
        {
            client = new ServerEventsClient(Url)
            {
                OnException = Console.WriteLine,
            };
        }

        public async Task Start()
        {
            await client.StartAsync();
        }

        public async Task<T> ConsumeNextMessage()
        {
            var message = await client.WaitForNextMessage();
            var payload = JsonSerializer.Deserialize<T>(message.Data) ??
                throw new Exception("paylod is not serializable");
            return payload;
        }

        public async Task Close()
        {
            await client.Stop();
        }
    }
}