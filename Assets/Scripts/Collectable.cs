using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool found = false;
    Collider2D text;
    Collider2D notebookCollider;
    public GameObject mouse;
    private FollowMouse mouseScript;
    private Notebook notebookScript;
    public GameObject notebook;
    Vector2 difference;
    public string itemName;


    float maxMoveSpeed;
    float smoothTime;
    Vector2 currentVelocity;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Collider2D>();
        notebookCollider = notebook.GetComponent<Collider2D>();
        mouseScript = mouse.GetComponent<FollowMouse>();
        notebookScript = notebook.GetComponent<Notebook>();
        maxMoveSpeed = mouseScript.maxMoveSpeed;
        smoothTime = mouseScript.smoothTime;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Collectable");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        /*if (hit.collider == text)
        {
            Debug.Log("Success! Hit " + hit.collider);
        }*/
        if (/*(*/mouse.GetComponent<Collider2D>().IsTouching(text) /*|| (hit.collider == text))*/ && Input.GetMouseButton(0))
        {
            difference = mouse.transform.position - transform.position;

            transform.position = Vector2.SmoothDamp(transform.position, (mousePosition - difference), ref currentVelocity, smoothTime, maxMoveSpeed);

            if (notebookCollider.IsTouching(text))
            {
                notebookScript.Collect(itemName);
                found = true;
            }
        }

        

        /*else
        {
            
        }*/


        if (found == true)
        {
            gameObject.SetActive(false);
        }
    }
}
