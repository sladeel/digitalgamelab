using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillKeywords : MonoBehaviour
{
    NotebookItem.wordTypes wordCategory;
    NotebookItem.nounTypes wordSubcategory;
    public GameObject parentNote;
    public bool secondary;                  //need to implement this so there's two of each but the second one only activates when the
    public KillButton killManager;          //first one is used
    List<GameObject> madlibsItems;
    Collider2D keyword;
    Renderer keywordRender;
    int page = 6;
    public NotebookHandler notebookHandler;
    bool onPage;
    public string id;
    MadlibsItem stuckTo;

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    Vector2 currentVelocity;
    Vector2 startPosition;
    Vector2 returnVelocity;
    // Start is called before the first frame update
    void Start()
    {
        wordCategory = parentNote.GetComponent<NotebookItem>().wordCategory;
        wordSubcategory = parentNote.GetComponent<NotebookItem>().wordSubcategory;
        madlibsItems = killManager.madlibsItems;
        keyword = GetComponent<Collider2D>();
        keywordRender = GetComponent<Renderer>();
        keyword.enabled = false;
        keywordRender.enabled = false;
        onPage = false;
        id = parentNote.GetComponent<NotebookItem>().id;
        stuckTo = null;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Kill Clue");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startPosition = parentNote.transform.position;

        if (hit.collider == keyword && Input.GetMouseButton(0)) //check if clicking on collider
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



        if (notebookHandler.position == "book")
        {
            foreach (GameObject field in madlibsItems)
            {
                //Debug.Log(field);
                Collider2D fieldCollider = field.GetComponent<Collider2D>();
                //Debug.Log(fieldCollider);
                MadlibsItem fieldScript = field.GetComponent<MadlibsItem>();
                bool freeField = fieldScript.currentItem == null || fieldScript.currentItem == id;
                /*if (fieldCollider.IsTouching(keyword))
                {
                    Debug.Log(gameObject + " touching " + field);
                }*/
                /*if (fieldCollider.IsTouching(keyword) &&  fieldScript.wordCategory == wordCategory)
                {
                    Debug.Log(gameObject + " and " + field + "share a category!");
                }*/

                if (fieldCollider.IsTouching(keyword) && (fieldScript.wordCategory == wordCategory) && freeField)
                {
                    //Debug.Log("touching and compatible!");
                    if (fieldScript.wordSubcategory != NotebookItem.nounTypes.nan && fieldScript.wordSubcategory == wordSubcategory)
                    {
                        //Debug.Log("matching subcategory!");
                        fieldScript.currentItem = id;
                        onPage = true;
                        stuckTo = fieldScript;
                    }
                    else if (fieldScript.wordSubcategory == NotebookItem.nounTypes.nan && fieldScript.wordCategory == wordCategory)
                    {
                        //Debug.Log("irrelevant subcategory!");
                        fieldScript.currentItem = id;
                        onPage = true;
                        stuckTo = fieldScript;
                    }
                }
            }
        }
        

        if (notebookHandler.page == 6)
        {
            bool touch = false;
            foreach (GameObject field in madlibsItems)
            {
                if ((field.GetComponent<MadlibsItem>() == stuckTo) && field.GetComponent<Collider2D>().IsTouching(keyword))
                {
                    touch = true;
                }
            }
            if (!touch)
            {
                if (stuckTo != null)
                {
                    stuckTo.currentItem = null;
                    stuckTo = null;
                }

            }
        }
        



        if (stuckTo == null)
        {
            onPage = false;
        }

        

        if (onPage == false && notebookHandler.grabbed != gameObject) //send any ungrabbed object not on page back to start location
        {
            transform.position = Vector2.SmoothDamp(transform.position, startPosition, ref returnVelocity, smoothTime, maxMoveSpeed);
        }


        if (notebookHandler.page == page && parentNote.activeInHierarchy) //sets clues visible only when on the correct page
        {
            keyword.enabled = true;
            keywordRender.enabled = true;
        }
        else
        {
            keyword.enabled = false;
            keywordRender.enabled = false;
        }
    }
}
