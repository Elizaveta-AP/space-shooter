[System.Serializable]

public class LeaderboardData
{
    public int[] Values;
    public string[] Names;

    
    public LeaderboardData()
    {
        Values = Leaderboard.CurrentLeaderboard.Values;
        Names = Leaderboard.CurrentLeaderboard.Names;
    }
}
