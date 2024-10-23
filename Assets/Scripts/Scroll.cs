using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    float height;
    public GetHeight bodyContent;
    float startPosition;
    public float screenHeight = 6.478982f;
    float difference = 0;
    public bool bugged;
    public float offset;

    /*public GameObject screenTop;
    public GameObject screenBottom;

    public GameObject top;
    public GameObject bottom;*/


    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position.y;
        if (bugged)
        {
            startPosition = startPosition + offset;
            //screenHeight = 0;
        }
        transform.position = new Vector2(transform.position.x, startPosition);
    }

    // Update is called once per frame
    void Update()
    {

        
        height = bodyContent.height;
        if (Input.mouseScrollDelta.y < 0 && transform.position.y < startPosition + height - (screenHeight + scrollSpeed)) //difference < height)//
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + scrollSpeed);
        }
        else if (Input.mouseScrollDelta.y > 0 && transform.position.y > startPosition) // difference > 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed);
        }
        /*if (Input.mouseScrollDelta.y < 0 && bottom.transform.position.y < screenBottom.transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + scrollSpeed);
        }
        else if (Input.mouseScrollDelta.y > 0 && top.transform.position.y > screenTop.transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed);
        }*/

        if (transform.position.y < startPosition)
        {
            transform.position = new Vector2(transform.position.x, startPosition);
        }

        difference = transform.position.y - startPosition;
    }

    public float Difference
    {
        get { return difference; }
    }

    public float StartPosition
    {
        get { return startPosition; }
    }
}
