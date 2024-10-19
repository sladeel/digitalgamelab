using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Website : MonoBehaviour
{
    public string url;
    //public GameObject website;
    public URLHandler handler;
    
    // Start is called before the first frame update
    void Start()
    {
        //website = GetComponent<GameObject>();
        handler.AddSite(url, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
