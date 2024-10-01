using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Collider2D mouse;
    Collider2D button;
    public GameObject CurrentPage;
    public GameObject NextPage;
    
    private GameObject CurrentBg;
    private GameObject NextBg;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Collider2D>();
        CurrentBg = CurrentPage.transform.parent.gameObject;
        NextBg = NextPage.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.IsTouching(button) && Input.GetMouseButtonDown(0))
        {
            CurrentPage.SetActive(false);
            NextPage.SetActive(true);

            if (CurrentBg != NextBg)
            {
                CurrentBg.SetActive(false);
                NextBg.SetActive(true);
            }
        }
    }
}
