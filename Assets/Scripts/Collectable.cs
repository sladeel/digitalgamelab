using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum wordTypes
    {
        noun,
        time,
        verb
    }
    
    public enum nounTypes
    {
        nan,
        code,
        location,
        suspect,
        weapon,
        website
    }
    
    
    bool found = false;
    Collider2D text;
    Collider2D notebookCollider;
    public GameObject mouse;
    private FollowMouse mouseScript;
    private Collector notebookScript;
    public GameObject notepad;
    Vector2 difference;
    public string itemName;
    public wordTypes wordCategory;
    public nounTypes wordSubcategory;
    float notepadMove;

    float maxMoveSpeed;
    float smoothTime;
    Vector2 currentVelocity;
    Vector2 startPosition;
    float screenDifference;
    Vector2 returnVelocity;

    Vector2 padVelocity;

    public bool bugged;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Collider2D>();
        notebookCollider = notepad.GetComponent<Collider2D>();
        mouseScript = mouse.GetComponent<FollowMouse>();
        notebookScript = notepad.GetComponent<Collector>();
        maxMoveSpeed = mouseScript.maxMoveSpeed;
        smoothTime = mouseScript.smoothTime;
        startPosition = transform.position;
        if (bugged)
        {
            startPosition = new Vector2 (startPosition.x, startPosition.y - offset);
        }
        transform.position = startPosition;

        if (wordCategory != wordTypes.noun)
        {
            wordSubcategory = nounTypes.nan;
        }
        notepadMove = notebookScript.notepadMove;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Collectable");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        try
        {
            screenDifference = GetComponentInParent<Scroll>().Difference;
        }
        catch
        {
            screenDifference = 0;
        }
        

        /*if (hit.collider == text)
        {
            Debug.Log("Success! Hit " + hit.collider);
        }*/
        if (/*(*/mouse.GetComponent<Collider2D>().IsTouching(text) /*|| (hit.collider == text))*/ && Input.GetMouseButton(0))
        {
            if (mouseScript.grabbed == null || mouseScript.grabbed == gameObject)
            {
                mouseScript.grabbed = gameObject;
                difference = mouse.transform.position - transform.position;

                transform.position = Vector2.SmoothDamp(transform.position, mousePosition - difference, ref currentVelocity, smoothTime, maxMoveSpeed);

                if (notebookCollider.IsTouching(text))
                {
                    notebookScript.Collect(itemName);
                    found = true;
                    mouseScript.grabbed = null;
                }
            }

            notepad.transform.position = Vector2.SmoothDamp(notepad.transform.position, new Vector2(notepad.transform.position.x, notepad.transform.position.y + notepadMove), ref padVelocity, smoothTime, maxMoveSpeed);
        }
        else
        {
            transform.position = Vector2.SmoothDamp(transform.position, (new Vector2(startPosition.x, startPosition.y + screenDifference)), ref returnVelocity, smoothTime, maxMoveSpeed);
            if (mouseScript.grabbed == gameObject)
            {
                mouseScript.grabbed = null;
            }
        }


        if (found == true)
        {
            gameObject.SetActive(false);
        }
    }
}
