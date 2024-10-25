using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingHandler : MonoBehaviour
{
    public TextMeshProUGUI speaker;
    public TextMeshProUGUI dialogue;
    public ExpressionHandler wife;
    public List<TextAsset> speakerFiles;
    TextAsset speakerFile;
    public List<TextAsset> dialogueFiles;
    TextAsset dialogueFile;
    public List<TextAsset> expressionFiles;
    TextAsset expressionFile;
    public RectTransform label;
    public string scene;
    public float wait = 0.5f;

    public string tempFile;

    char[] seperators = new char[] {'\n', '\r' };

    private string[] speakerList;
    private string[] dialogueList;
    private string[] expressionList;
    private int position;

    MurderHandler murder;

    // Start is called before the first frame update
    void Start()
    {
        murder = GameObject.FindAnyObjectByType<MurderHandler>();
        int end = (int)murder.ending;
        speakerFile = speakerFiles[end];
        dialogueFile = dialogueFiles[end];
        expressionFile = expressionFiles[end];

        position = 0;
        speakerList = speakerFile.text.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);
        dialogueList = dialogueFile.text.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);
        expressionList = expressionFile.text.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);
        
        wife.Express(expressionList[position]);
    }

    // Update is called once per frame
    void Update()
    {
        speaker.text = speakerList[position];
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
        if (speakerList.Length - 1 != position)
        {
            position++;
            wife.Express(expressionList[position]);
            //StartCoroutine(DisplayText());
            //Debug.Log(expressionList[position]);
        }
        else
        {
            SceneManager.LoadScene(scene);
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
