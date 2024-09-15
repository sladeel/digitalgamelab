using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool found = false;
    Collider2D text;
    public GameObject mouse;
    private FollowMouse script;
    public Collider2D notebook;
    Vector2 difference;
    


    float maxMoveSpeed;
    float smoothTime;
    Vector2 currentVelocity;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Collider2D>();
        script = mouse.GetComponent<FollowMouse>();
        maxMoveSpeed = script.maxMoveSpeed;
        smoothTime = script.smoothTime;
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

            if (notebook.IsTouching(text))
            {
                //add to notebook array
                found = true;
            }
        }
        else
        {
            
        }


        if (found == true)
        {
            gameObject.SetActive(false);
        }
    }
}
