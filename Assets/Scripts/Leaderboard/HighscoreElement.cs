using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    public List<Score> highscoreList = new List<Score>();
    [SerializeField] int maxCount = 5;
    string filename = "scoreboard.json";

    private void Start()
    {
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<Score>(filename);

        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }
    }

    public void AddHighscoreIfPossible (double score)
    {
        Score newScore = new Score(PlayerPrefs.GetString("PlayerName"), score);
        highscoreList = FileHandler.ReadListFromJSON<Score>(filename);
        for (int i=0; i<maxCount; i++)
        {
            if( i>= highscoreList.Count || newScore.score < highscoreList[i].score)
            {
                highscoreList.Insert(i, newScore);
                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                FileHandler.SaveToJSON<Score>(highscoreList, filename);

                break;
            }
        }
    }
}
