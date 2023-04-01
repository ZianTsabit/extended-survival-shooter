using UnityEngine;
using UnityEngine.UI;

public class Zombunny_1 : MonoBehaviour
{
    public static int enemyKilled;
    public static int targetKill = 10;

    Text text;
    // Start is called before the first frame update
    void Awake ()
    {
        text = GetComponent<Text>();
        enemyKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = enemyKilled + " / " + targetKill;
    }
}
