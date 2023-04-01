using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            if (textComponent.text == "(Exit cutscene with LEFT CLICK)")
            {
                int sceneIdx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

                if (sceneIdx == 0 || sceneIdx == 2)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                }

                //UnityEngine.SceneManagement.SceneManager.LoadScene("Level_01");
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            textComponent.text = "(Exit cutscene with LEFT CLICK)";
        }
    }
}
