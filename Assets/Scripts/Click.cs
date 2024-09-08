using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Collider2D mouse;
    Collider2D button;
    public GameObject CurrentPage;
    public GameObject NextPage;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.IsTouching(button) && Input.GetMouseButtonDown(0))
        {
            CurrentPage.SetActive(false);
            NextPage.SetActive(true);
        }
    }
}
