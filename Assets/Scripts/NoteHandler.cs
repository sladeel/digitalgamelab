using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    public int page;
    Vector2 difference;
    Collider2D clue;
    Renderer clueRender;
    bool onPage = false;
    public GameObject notebook;
    Collider2D notebookCollider;
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
        
        

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Collectable");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        startPosition = parentClue.transform.position;

        /*if (hit.collider == text)
        {
            Debug.Log("Success! Hit " + hit.collider);
        }*/
        if (/*(mouse.GetComponent<Collider2D>().IsTouching(clue) ||*/ (hit.collider == clue) && Input.GetMouseButton(0))
        {
            difference = mousePosition - new Vector2 (transform.position.x, transform.position.y);

            transform.position = Vector2.SmoothDamp(transform.position, (mousePosition - difference), ref currentVelocity, smoothTime, maxMoveSpeed);

            if (notebookCollider.IsTouching(clue))
            {
                
                onPage = true;
            }
        }
        else if (onPage == false)
        {
            transform.position = Vector2.SmoothDamp(transform.position, (new Vector2(startPosition.x, startPosition.y + screenDifference)), ref returnVelocity, smoothTime, maxMoveSpeed);
        }

        if (notebookHandler.page == page)
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
