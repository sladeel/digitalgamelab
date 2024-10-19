using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPageForce : MonoBehaviour
{
    public NotebookHandler book;
    public Collider2D collide;
    public int page;

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
            //Debug.Log("Hit Page Turn!");
            book.page = page;
        }
    }
}
