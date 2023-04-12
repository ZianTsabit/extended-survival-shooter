using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField nameInput;
    string filename= "scoreboard.json";
    [SerializeField] int maxCount = 5;

    List<Score> highscoreList = new List<Score>();

    private void Start()
    {
        highscoreList = FileHandler.ReadListFromJSON<Score>(filename);
    }

    public void AddNewHighscore(double score)
    {
        Score newScore = new Score(PlayerPrefs.GetString("PlayerName"), score);
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highscoreList.Count || newScore.score < highscoreList[i].score)
            {
                highscoreList.Insert(i, newScore);
                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                break;
            }
        }
        //highscoreList.Add(new Score(nameInput.text, Random.Range(0, 100)));
        FileHandler.SaveToJSON<Score>(highscoreList, filename);
    }

    public void AddNew()
    {
        Score newScore = new Score(PlayerPrefs.GetString("PlayerName"), Random.Range(0, 100));
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highscoreList.Count || newScore.score < highscoreList[i].score)
            {
                highscoreList.Insert(i, newScore);
                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                break;
            }
        }
        //highscoreList.Add(new Score(nameInput.text, Random.Range(0, 100)));
        FileHandler.SaveToJSON<Score>(highscoreList, filename);
    }

}
