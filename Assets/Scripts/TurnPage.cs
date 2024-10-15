using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour
{
    public bool forwards;
    public NotebookHandler book;
    public Collider2D collide;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1);

        if (Input.GetMouseButtonDown(0) && hit.collider == collide)
        {
            Debug.Log("Hit Page Turn!");
            if (forwards && book.page != book.length)
            {
                book.page ++;
                Debug.Log("Turned Page Forwards! Now on page: " + book.page);                
            }
            else if (!forwards && book.page != 1)
            {
                book.page--;
                Debug.Log("Turned Page Backwards! Now on page: " + book.page);
            }
        }
    }
}
