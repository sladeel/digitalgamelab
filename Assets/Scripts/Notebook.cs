using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public List<string> collected;
    public AudioSource sound;
    public Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        collected = new List<string>();
        location = new Vector3(-6.59f, 5.82f, 5.736762f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect(string item)
    {
        
        
        collected.Add(item);
        BroadcastMessage("Display", location);


        List<MonoBehaviour> monoList = new List<MonoBehaviour>();
        GetComponentsInChildren<MonoBehaviour>(true, monoList);
        for (int i = 0; i < monoList.Count; i++)
        {
            monoList[i].Invoke("Display", 0);
        }


        //sound.Play();
        location = new Vector3(Random.Range(-7f, -2.6f), location.y + 0.9f, 5.736762f);
        
        
    }
}
