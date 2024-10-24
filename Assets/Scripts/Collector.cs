using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<string> collected;
    public AudioSource sound;
    public Vector3 location;
    public TextHandler phone;

    // Start is called before the first frame update
    void Start()
    {
        collected = new List<string>();
        location = new Vector3(-0.09f, 1.416f, 0.2326224f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect(string item)
    {
        
        
        collected.Add(item);
        BroadcastMessage("Display");


        List<MonoBehaviour> monoList = new List<MonoBehaviour>();
        GetComponentsInChildren<MonoBehaviour>(true, monoList);
        for (int i = 0; i < monoList.Count; i++)
        {
            monoList[i].Invoke("Display", 0);
        }


        sound.Play();
        location = new Vector3(Random.Range(-0.09f, 0.09f), location.y - 0.425f, 5.736762f); //passing location is no longer necessary
                                                                                             //but functionality remains in case later builds
        Debug.Log(collected.Count);                                                          //call for it
        if (collected.Count % 10 == 0)
        {
            phone.NewThread();
        }
        
    }
}
