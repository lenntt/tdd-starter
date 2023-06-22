using Result;

Console.WriteLine("Let's play some bowling!");
var game = new PlayGame(
    new HttpStream<BowlingMessage>("https://tdd-bowling-alcckkju2q-ez.a.run.app/"),
    (GameState state) =>
    {
        Console.WriteLine($"pins: [{string.Join(", ", state.Throws)}] score: {state.Score}");
        Console.CursorTop--;
    },
    (int score) =>
    {
        Console.CursorTop++;
        Console.WriteLine($"Finished game with a grand total of {score} 🎉");
    }
);

await game.Start();
