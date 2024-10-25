using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    public int page;
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
    Vector2 returnVelocity;

    // Start is called before the first frame update
    void Start()
    {
        clue = GetComponent<Collider2D>();
        clueRender = GetComponent<Renderer>();
        notebookCollider = notebook.GetComponent<Collider2D>();

        clue.enabled = false;
        clueRender.enabled = false;

        //Debug.Log(clue.enabled);
    }

    // Update is called once per frame
    void Update()
    {
        if (notebookHandler.position == "book")
        { 
        LayerMask mask = LayerMask.GetMask("Clue");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startPosition = parentClue.transform.position;

        if (hit.collider == clue && Input.GetMouseButton(0)) //check if clicking on collider
        {
            if (notebookHandler.grabbed == null || notebookHandler.grabbed == gameObject) //check grabbed isn't set to another object
            {
                notebookHandler.grabbed = gameObject; //set grabbed to this object
            }
        }

        if (notebookHandler.grabbed == gameObject) //check if this object is grabbed
        {
            transform.position = mousePosition; //follow mouse while grabbed
        }


        if (notebookCollider.IsTouching(clue) && !notNotebookCollider.IsTouching(clue)) //check that the notebook collider is touching and the not notebook collider isnt touching
        {
            onPage = true;
        }
        else if (clue.enabled)
        {
            onPage = false;
        }

        if (onPage == false && notebookHandler.grabbed != gameObject) //send any ungrabbed object not on page back to start location
        {
            transform.position = Vector2.SmoothDamp(transform.position, startPosition, ref returnVelocity, smoothTime, maxMoveSpeed);
        }
        }

        if (notebookHandler.page == page && parentClue.active) //sets clues visible only when on the correct page
        {
            clue.enabled = true;
            clueRender.enabled = true;
        }
        else
        {
            clue.enabled = false;
            clueRender.enabled = false;
        }

    }
}
