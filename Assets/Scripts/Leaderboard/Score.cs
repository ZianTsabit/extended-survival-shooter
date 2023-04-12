using System;

[Serializable]
public class Score 
{
    public string playerName;
    public double score;

    public Score(string playerName, double score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
