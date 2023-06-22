namespace Result;
public static class Bowling
{
    public static int Score(List<int> input ) {
        var score = 0;
        var throwIndex = 0;

        static int getPins(int index, List<int> input)
        {
            if (index < input.Count)
            {
                return input[index];
            }
            else
            {
                return 0;
            }
        }

        for (int frame = 0; frame < 10; frame++)
        {
            if (getPins(throwIndex, input) == 10) {
                score += 10 + getPins(throwIndex + 1, input) + getPins(throwIndex + 2, input);
                throwIndex++;
            } else if (getPins(throwIndex, input) + getPins(throwIndex+1, input) == 10) {
                score += 10 + getPins(throwIndex + 2, input);
                throwIndex++;
                throwIndex++;
            } else {
                score += getPins(throwIndex, input) + getPins(throwIndex + 1, input);
                throwIndex++;
                throwIndex++;
            }
        }

        return score;
    }
}
