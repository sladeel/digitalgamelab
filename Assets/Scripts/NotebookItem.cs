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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        active = false;
        collide = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1);

        if (Input.GetMouseButtonDown(0) && hit == collide)
        {
            GameObject clone = Instantiate(gameObject);
            
            //everything beyond here is the code from notehandler.update
            RaycastHit2D hitClone = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((hit.collider == clone) && Input.GetMouseButton(0)) 
            {

                if (notebookHandler.grabbed == null || notebookHandler.grabbed == clone)
                {
                    notebookHandler.grabbed = clone;
                    
                    clone.transform.position = mousePosition; 

                }

            }
            else 
            {
                Destroy(clone);
            }
                                                 


        }
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
}
