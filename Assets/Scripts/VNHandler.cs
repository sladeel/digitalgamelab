using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VNHandler : MonoBehaviour
{
    public TextMeshProUGUI speaker;
    public TextMeshProUGUI dialogue;
    public TextAsset speakerFile;
    public TextAsset dialogueFile;
    public RectTransform label;
    public string scene;
    public float wait = 0.5f;

    private string[] speakerList;
    private string[] dialogueList;
    private int position;

    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        speakerList = speakerFile.text.Split('\n');
        dialogueList = dialogueFile.text.Split('\n');
        
    }

    // Update is called once per frame
    void Update()
    {
        speaker.text = speakerList[position];
        dialogue.text = dialogueList[position];

        if (speakerList[position] == "You" || speakerList[position] == "You\r")
        {
            label.anchoredPosition = new Vector2(620, -184.201f);
        }
        else
        {
            label.anchoredPosition = new Vector2(-589.8546f, -184.201f);
        }

    }

    public void Advance()
    {
        if (speakerList.Length - 1 != position)
        {
            position++;
            //StartCoroutine(DisplayText());
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
