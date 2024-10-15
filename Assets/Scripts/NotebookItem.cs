using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookItem : MonoBehaviour
{
    public string id;
    public Collector notebook;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display()
    {
        if (notebook.collected[notebook.collected.Count - 1] == id)
        {
            transform.localPosition = notebook.location;
            gameObject.SetActive(true);
            active = true;
        }
        
     }
}
