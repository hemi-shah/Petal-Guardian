public static class Score
{
    private static int score = 0;

    public static void Reset()
    {
        score = 0;
    }
    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public static int GetScore()
    {
        return score;
    }
    
    public static string GetScoreString()
    {
        return score.ToString();
    }
}
