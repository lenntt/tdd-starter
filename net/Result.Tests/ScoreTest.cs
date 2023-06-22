namespace Result.Tests;

public class ScoreTest
{
    [Fact]
    public void NoPoints()
    {
        Assert.Equal(0, Bowling.Score(new List<int> {} ));
        Assert.Equal(0, Bowling.Score(new List<int> {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} ));
    }

    [Fact]
    public void NormalFrames()
    {
        Assert.Equal(1, Bowling.Score(new List<int> {1} ));
        Assert.Equal(1, Bowling.Score(new List<int> {0,1} ));
    }

    [Fact]
    public void StrikeFrames()
    {
        Assert.Equal(12 + 2, Bowling.Score(new List<int> {10, 1, 1} ));
        Assert.Equal(11 + 1, Bowling.Score(new List<int> {10, 1}));
        Assert.Equal(12, Bowling.Score(new List<int> {0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0, 10,1,1} ));
    }

    [Fact]
    public void SpareFrames()
    {
        Assert.Equal(11 + 2, Bowling.Score(new List<int> {5,5,1,1} ));
        Assert.Equal(20 + 14 + 4, Bowling.Score(new List<int> {5,5,10,2,2} ));
        Assert.Equal(20 + 14 + 4, Bowling.Score(new List<int> {5,5,10,2,2} ));
    }
}