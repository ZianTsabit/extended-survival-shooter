using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public string levelName;
    public int[] enemyTypes;
    public int[] targetKills;
    public static int[] currKills;

    public Text questList;

    // Start is called before the first frame update
    void Start()
    {
        // initiate three types of enemies
        currKills = new int[enemyTypes.Length];
        for(int i = 0; i < enemyTypes.Length; i++)
        {
            currKills[i] = Math.Min(0, enemyTypes[i]); // if -1 then assign -1 to currKills
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool questCompleted = true;
        questList.text = string.Empty;
        questList.text += levelName + "\n";
        string Lwrapper = string.Empty;
        string Rwrapper = string.Empty;

        // Unpack all of the enemies
        for (int i = 0; i < enemyTypes.Length; i++)
        {
            // Enemy type
            switch (enemyTypes[i])
            {
                case 0:
                    questList.text += "Kill Zombunny\n";
                    break;
                case 1:
                    questList.text += "Kill Zombear\n";
                    break;
                case 2:
                    questList.text += "Kill Hellephant\n";
                    break;
                default:
                    continue;
            }

            // Kill amount
            if (currKills[i] >= targetKills[i])
            {
                Lwrapper = "<color=green>";
                Rwrapper = "</color>";
            }
            else
            {
                questCompleted = false;
                Lwrapper = Rwrapper = string.Empty;
            }
            questList.text += Lwrapper + currKills[i] + " / " + targetKills[i] + Rwrapper + "\n\n";
        }


        // Check if quest has been completed or not
        if (questCompleted && !ShopScript.afterQuestShopping)
        {
            
            // Reward for completing quest
            string sceneName = SceneManager.GetActiveScene().name;
            switch(sceneName)
            {
                case "Level_1":
                    MoneyManager.money += 50;
                    break;
                case "Level_2":
                    MoneyManager.money += 100;
                    break;
                case "Level_3":
                    MoneyManager.money += 150;
                    break;
                case "Level_4":
                    SceneManager.LoadScene("Closing");
                    break;
                default:
                    break;
            }
            TimeManager.prevSecond += TimeManager.currentSecond;
            MoneyManager.prevMoney += MoneyManager.money;
            Debug.Log(MoneyManager.money);
            MoneyManager.money = 0;
            Debug.Log(MoneyManager.prevMoney);

            ShopScript.afterQuestShopping = true;
        }
    }

}
