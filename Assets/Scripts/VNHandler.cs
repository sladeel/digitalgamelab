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
    public string scene;

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
    }

    public void Advance()
    {
        if (speakerList.Length - 1 != position)
        {
            position++;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
        
    }
}
