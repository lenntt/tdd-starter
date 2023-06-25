using ServiceStack;

var client = new ServerEventsClient("https://tdd-bowling-alcckkju2q-ez.a.run.app/");
client.Start();

while (true) {
    var message = await client.WaitForNextMessage();
    Console.WriteLine(message.Data);
}