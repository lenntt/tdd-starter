namespace Result.Tests;

public class PlayGameTest
{

    [Fact]
    public void ConsumeMessagesAndTallyScore()
    {
        var stream = new FakeStream();

        GameState? nextThrowLastCalled = null;
        var game = new PlayGame(stream, m => nextThrowLastCalled = m, m => { });

        game.Start();

        stream.Next(new BowlingMessage("next", 2));
        Assert.Equal(2, nextThrowLastCalled?.Score);

        stream.Next(new BowlingMessage("next", 3));
        Assert.Equal(5, nextThrowLastCalled?.Score);
    }

    [Fact]
    public void EndTheGame()
    {
        var stream = new FakeStream();

        GameState? nextThrowLastCalled = null;
        int? scoreWhenGameIsCompleted = null;
        var game = new PlayGame(stream, m => nextThrowLastCalled = m, m => scoreWhenGameIsCompleted = m);

        var gameTask = game.Start();
        stream.Next(new BowlingMessage("end", 2));

        gameTask.Wait();
        Assert.Equal(2, nextThrowLastCalled?.Score);
        Assert.Equal(2, scoreWhenGameIsCompleted);
        Assert.True(stream.hasBeenClosed);
        Assert.True(gameTask.IsCompletedSuccessfully);
    }


    [Fact]
    public void PlayRealisticGame()
    {
        var stream = new FakeStream();

        GameState? nextThrowLastCalled = null;
        int? scoreWhenGameIsCompleted = null;
        var game = new PlayGame(stream, m => nextThrowLastCalled = m, m => scoreWhenGameIsCompleted = m);

        List<int> gameExceptLastThrow = new() { 10, 0, 9, 7, 0, 5, 1, 0, 10, 1, 4, 3, 0, 8, 2, 4, 1, 5, 5 };
        var lastThrow = 3;

        var gameTask = game.Start();

        gameExceptLastThrow.ForEach(x => stream.Next(new BowlingMessage("next", x)));
        stream.Next(new BowlingMessage("end", lastThrow));

        gameTask.Wait();
        Assert.Equal(gameExceptLastThrow.Concat(new List<int>{lastThrow}).ToList(), nextThrowLastCalled?.Throws);
        Assert.Equal(92, nextThrowLastCalled?.Score);
    }
}

class FakeStream : IStream<BowlingMessage>
{
    private Task<BowlingMessage>? currentTask;
    private BowlingMessage? nextMessage;
    public bool hasBeenClosed = false;

    public void Next(BowlingMessage message)
    {
        nextMessage = message;
        (currentTask ?? throw new Exception()).RunSynchronously();
    }

    public Task Close()
    {
        hasBeenClosed = true;
        return Task.CompletedTask;

    }

    public Task<BowlingMessage> ConsumeNextMessage()
    {
        currentTask = new Task<BowlingMessage>(() => nextMessage ?? throw new Exception());
        return currentTask;
    }

    public Task Start()
    {
        return Task.CompletedTask;
    }
}