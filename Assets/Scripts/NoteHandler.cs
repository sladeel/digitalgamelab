using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    public int page;
    Vector2 difference;
    Collider2D clue;
    Renderer clueRender;
    public bool onPage = false;
    public GameObject notebook;
    Collider2D notebookCollider;
    public CompositeCollider2D notNotebookCollider;
    public NotebookHandler notebookHandler;
    public NotebookItem parentClue;

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    Vector2 currentVelocity;
    Vector2 startPosition;
    float screenDifference;
    Vector2 returnVelocity;

    // Start is called before the first frame update
    void Start()
    {
        clue = GetComponent<Collider2D>();
        clueRender = GetComponent<Renderer>();
        notebookCollider = notebook.GetComponent<Collider2D>();

        clue.enabled = !clue.enabled;
        clueRender.enabled = !clueRender.enabled;

        //Debug.Log(clue.enabled);
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Clue");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        startPosition = parentClue.transform.position;

        if (notNotebookCollider.IsTouching(clue))
        {
            Debug.Log(clue + " is touching " + notNotebookCollider);
        }

        if (hit.collider == clue && Input.GetMouseButton(0)) //check if clicking on collider
        {
            //Debug.Log("Success! Hit " + hit.collider);
        }
        if (/*(mouse.GetComponent<Collider2D>().IsTouching(clue) ||*/ (hit.collider == clue) && Input.GetMouseButton(0)) //check if clicking on collider. again. dw about it
        {
            
            if (notebookHandler.grabbed == null || notebookHandler.grabbed == gameObject)
            {
                notebookHandler.grabbed = gameObject;
                //Debug.Log("THINGS ARE OCCURING");
                //difference = mousePosition - new Vector2 (transform.position.x, transform.position.y); //this is supposed to get the location of click relative to the pivot of the object
                difference = new Vector2(0, 0); //this is what happens when the code above breaks.

                //transform.position = Vector2.SmoothDamp(transform.position, (mousePosition - difference), ref currentVelocity, smoothTime, maxMoveSpeed); //this used to follow on a delay. it was bad. in retrospect i dont know why i included it
                transform.position = mousePosition; //follows the mouse. could probably factor in that difference math if i tried

            }



            if (notebookCollider.IsTouching(clue) && !notNotebookCollider.IsTouching(clue)) //check that the notebook collider is touching and the not notebook collider isnt touching
            {
                //Debug.Log("Success! " + clue + " is touching " + notebookCollider);
                onPage = true;
            }
            else
            {
                onPage = false;
            }
        }
        else if (onPage == false)
        {
            if (notebookHandler.grabbed == gameObject)
            {
                notebookHandler.grabbed = null;
            }
            
            transform.position = Vector2.SmoothDamp(transform.position, (new Vector2(startPosition.x, startPosition.y + screenDifference)), ref returnVelocity, smoothTime, maxMoveSpeed);
        }
        else if (notebookHandler.grabbed == gameObject)
        {
                notebookHandler.grabbed = null;
        }

        if (notebookHandler.page == page && parentClue.active)
        {
            if (clue.enabled != true)
            {
                clue.enabled = !clue.enabled;
                clueRender.enabled = !clueRender.enabled;
            }
        }
        else
        {
            if (clue.enabled == true)
            {
                clue.enabled = !clue.enabled;
                clueRender.enabled = !clueRender.enabled;
            }
        }

    }
}
