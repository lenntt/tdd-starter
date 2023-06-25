namespace Result.Tests;

public class PlayGameTest
{
    [Fact]
    public async void ShouldOpenStreamWhenGameIsStarted()
    {
        var stream = new FakeStream();
        var game = new PlayGame(stream, m => {}, m => { });

        await game.Start();

        Assert.True(stream.hasBeenOpened);
    }

    [Fact]
    public async void ConsumeMessagesAndTallyScore()
    {
        var stream = new FakeStream();

        GameState? nextThrowLastCalled = null;
        var game = new PlayGame(stream, m => nextThrowLastCalled = m, m => { });

        await game.Start();

        stream.Next(new BowlingMessage("next", 2));
        Assert.Equal(2, nextThrowLastCalled?.Score);

        stream.Next(new BowlingMessage("next", 3));
        Assert.Equal(5, nextThrowLastCalled?.Score);
    }

    [Fact]
    public async void EndTheGame()
    {
        var stream = new FakeStream();

        GameState? nextThrowLastCalled = null;
        int? scoreWhenGameIsCompleted = null;
        var game = new PlayGame(stream, m => nextThrowLastCalled = m, m => scoreWhenGameIsCompleted = m);

        await game.Start();
        
        stream.Next(new BowlingMessage("end", 2));
        Assert.Equal(2, nextThrowLastCalled?.Score);
        Assert.Equal(2, scoreWhenGameIsCompleted);
        Assert.True(stream.hasBeenClosed);
    }


    [Fact]
    public async void PlayRealisticGame()
    {
        var stream = new FakeStream();

        GameState? nextThrowLastCalled = null;
        int? scoreWhenGameIsCompleted = null;
        var game = new PlayGame(stream, m => nextThrowLastCalled = m, m => scoreWhenGameIsCompleted = m);

        List<int> gameExceptLastThrow = new() { 10, 0, 9, 7, 0, 5, 1, 0, 10, 1, 4, 3, 0, 8, 2, 4, 1, 5, 5 };
        var lastThrow = 3;

        await game.Start();

        gameExceptLastThrow.ForEach(x => stream.Next(new BowlingMessage("next", x)));
        stream.Next(new BowlingMessage("end", lastThrow));

        Assert.Equal(gameExceptLastThrow.Concat(new List<int>{lastThrow}).ToList(), nextThrowLastCalled?.Throws);
        Assert.Equal(92, nextThrowLastCalled?.Score);
    }
}

class FakeStream: IStream<BowlingMessage>
{
    private Action<BowlingMessage>? onMessage;
    public bool hasBeenClosed = false;
    public bool hasBeenOpened = false;

    public void Next(BowlingMessage message)
    {
        onMessage?.Invoke(message);
    }

    public Task Close()
    {
        hasBeenClosed = true;
        return Task.CompletedTask;

    }

    public Task Start(Action<BowlingMessage> onMessage)
    {
        this.onMessage = onMessage;
        hasBeenOpened = true;
        return Task.CompletedTask;
    }
}

// => we geven ze het consumeren van de stream
// 1. Hoe maak je deze stream testbaar? Hoe neem je controle? Hoe maak je een mock/fake? 20min
// => we geven ze een fake stream
// => als ze er niet uitkomen: we geven ze een test die de fake stream gebruikt

// 2. Integreer de scorefunctie
// Welke testen zou je verwachten met de Fake stream, welke alleen met de score functie?

// 3. Hang dit aan de Console UI. Hoe maak je een UI zonder logic?