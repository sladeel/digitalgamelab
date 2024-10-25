using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderHandler : MonoBehaviour
{
    public string victim;
    public string pronoun;
    public KillButton.endingType ending;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
