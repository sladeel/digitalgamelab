using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public GameObject CurrentPage;
    public GameObject NextPage;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPage.SetActive(false);
        NextPage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
