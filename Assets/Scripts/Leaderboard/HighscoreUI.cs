using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject>();

    private void Start()
    {
        List<Score> list = FileHandler.ReadListFromJSON<Score>("scoreboard.json");
        UpdateUI(list);
    }
    public void UpdateUI(List<Score> list)
    {
        for (int i = 0; i<list.Count; i++)
        {
            Score el = list[i];
            if (el.score > 0)
            {
                if (i>= uiElements.Count){
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    uiElements.Add(inst);
                }

                var text = uiElements[i].GetComponentsInChildren< TMPro.TMP_Text>();
                text[0].text = (i + 1).ToString();
                text[1].text = el.playerName;
                text[2].text = el.score.ToString(); ;
            }


        }
    }
}
