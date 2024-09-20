using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    float height;
    float startPosition;
    float screenHeight = 6.549636f;
    float difference = 0;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y;
        startPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 && transform.position.y < startPosition + height - (screenHeight + scrollSpeed))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + scrollSpeed);
        }
        else if (Input.mouseScrollDelta.y > 0 && transform.position.y > startPosition)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed);
        }
        difference = transform.position.y - startPosition;
    }

    public float Difference
    {
        get { return difference; }
    }
}
