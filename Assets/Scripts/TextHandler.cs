using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextHandler : MonoBehaviour
{
    public FollowMouse mouseActive;
    public TextMeshProUGUI speaker;
    public TextMeshProUGUI dialogue;
    public TextAsset[] speakerFiles;
    public TextAsset[] dialogueFiles;
    public RectTransform label;
    public float wait = 0.5f;


    char[] seperators = new char[] { '\n', '\r' };

    private string[] speakerList;
    private string[] dialogueList;
    private int position;
    private int currentThread;
    public bool readThread;

    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        currentThread = -1;
        readThread = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        



    }

    public void NewThread()
    {
        currentThread++;
        speakerList = speakerFiles[currentThread].text.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);
        dialogueList = dialogueFiles[currentThread].text.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);
    }

    public void Advance()
    {
        if (speakerList.Length - 1 != position)
        {
            position++;
            speaker.text = speakerList[position];
            dialogue.text = dialogueList[position];

            if (speakerList[position] == "You")
            {
                label.anchoredPosition = new Vector2(620, -184.201f);
            }
            else
            {
                label.anchoredPosition = new Vector2(-589.8546f, -184.201f);
            }
            //StartCoroutine(DisplayText());
        }
        else
        {
            readThread = true;
            mouseActive.screenActive = true;
        }

    }

    IEnumerator DisplayText()
    {
        for (int i = 0; i < dialogueList[position].Length; i++)
        {
            dialogue.text = dialogueList[position].Substring(0, i + 1);
            //Debug.Log(dialogueList[position].Substring(0, i + 1));
            yield return new WaitForSeconds(wait);
        }
    }
}
