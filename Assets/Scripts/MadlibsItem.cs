using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadlibsItem : MonoBehaviour
{
    public NotebookItem.wordTypes wordCategory;
    public NotebookItem.nounTypes wordSubcategory;
    public KillButton killManager;
    public string currentItem;
    
    // Start is called before the first frame update
    void Start()
    {
        killManager.madlibsItems.Add(gameObject);
        currentItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
