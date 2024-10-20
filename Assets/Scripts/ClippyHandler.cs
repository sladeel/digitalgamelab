using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ClippyHandler : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public TextAsset dialogueFile;
    public float wait = 0.5f;


    char[] seperators = new char[] { '\n', '\r' };

    private string[] dialogueList;
    private int position;

    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        dialogueList = dialogueFile.text.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);
        
    }

    // Update is called once per frame
    void Update()
    {
        dialogue.text = dialogueList[position];


        /*if (speakerList[position] == "You" || speakerList[position] == "You\r")  //This is a feature I like to call David Mode. I should like. Set it up fr.
        {
            label.anchoredPosition = new Vector2(620, -184.201f);
        }
        else
        {
            label.anchoredPosition = new Vector2(-589.8546f, -184.201f);
        }*/



    }

    public void Advance()
    {
        if (dialogueList.Length - 1 != position)
        {
            position++;

            //StartCoroutine(DisplayText());
            //Debug.Log(expressionList[position]);
        }
        else
        {
            gameObject.SetActive(false);
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
