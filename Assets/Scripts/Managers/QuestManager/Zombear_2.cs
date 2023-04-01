using UnityEngine;
using UnityEngine.UI;

public class Zombear_2 : MonoBehaviour
{
    public static int enemyKilled;
    public static int targetKill = 2;

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
        if (enemyKilled >= targetKill)
        {
            text.color = Color.green;
        }
    }
}
