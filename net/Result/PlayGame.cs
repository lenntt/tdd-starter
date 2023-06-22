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
            bool keepPlaying = true;
            List<int> throws = new();

            await Source.Start();
            while (keepPlaying)
            {
                var message = await Source.ConsumeNextMessage();
                throws.Add(message.pins);

                var score = Bowling.Score(throws);
                OnNewThrow(new GameState(throws, score));

                if (message.state == "end") {
                    OnEndGame(score);
                    await Source.Close();
                    keepPlaying = false;
                }
            }
        }
    }

    public record GameState(List<int> Throws, int Score);

    public record BowlingMessage(string state, int pins);
}