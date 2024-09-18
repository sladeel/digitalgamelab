using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    List<string> collected;
    string example;
    public AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        collected = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect(string item)
    {
        collected.Add(item);
        //sound.Play();
        Debug.Log(collected[(collected.Count - 1)] + " added to notebook!");
    }
}
