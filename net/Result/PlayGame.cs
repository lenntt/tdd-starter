namespace Result
{
    public class PlayGame
    {
        private readonly IStream<BowlingMessage> Source;
        private Action<GameState> OnNewThrow { get; }
        private Action<int> OnEndGame { get; }
        public PlayGame(IStream<BowlingMessage> source, Action<GameState> OnNewThrow, Action<int> OnEndGame)
        {
            Source = source;
            this.OnNewThrow = OnNewThrow;
            this.OnEndGame = OnEndGame;
        }

        public async Task Start() {
            List<int> throws = new();

            await Source.Start((message) => {
                throws.Add(message.pins);
                OnNewThrow(new GameState(throws, Bowling.Score(throws)));

                if (message.state == "end") {
                    OnEndGame(Bowling.Score(throws));
                    Source.Close();
                }
            });
        }
    }

    public record GameState(List<int> Throws, int Score);

    public record BowlingMessage(string state, int pins);
}