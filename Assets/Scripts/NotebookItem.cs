using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookItem : MonoBehaviour
{
    public string id;
    public Collector notebook;
    public bool active;
    Collider2D collide;
    public NotebookHandler notebookHandler;
    GameObject clone;
    bool isClone;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        active = false;
        collide = GetComponent<Collider2D>();
        isClone = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1);

        if (Input.GetMouseButtonDown(0) && hit == collide && !isClone)
        {
            GameObject clone = Instantiate(gameObject, transform.parent);
            notebookHandler.grabbed = clone;
            clone.SetActive(true);
            clone.GetComponent<NotebookItem>().IsClone = true;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isClone && notebookHandler.grabbed == gameObject)
        {
            transform.position = mousePosition;
        }
        else if (isClone)
        {
            Destroy(gameObject);
        }*/
    }

    public void Display()
    {
        if (notebook.collected[notebook.collected.Count - 1] == id)
        {
            //transform.localPosition = notebook.location;
            gameObject.SetActive(true);
            active = true;
        }
        
     }

    public bool IsClone
    {
        set { isClone = value; }
    }
}
