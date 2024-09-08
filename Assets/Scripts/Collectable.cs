using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool found = false;
    Collider2D text;
    public GameObject mouse;
    public Collider2D notebook;
    Vector2 position;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Collider2D>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((mouse.GetComponent<Collider2D>().IsTouching(text) || ) && Input.GetMouseButton(0))
        {
            transform.position = mouse.transform.position;
            if (notebook.IsTouching(text))
            {
                //add to notebook array
                found = true;
            }
        }
        else
        {

        }
        

        if (found == true)
        {
            gameObject.SetActive(false);
        }
    }
}
