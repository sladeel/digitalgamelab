using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool found = false;
    Collider2D text;
    public GameObject mouse;
    public Collider2D notebook;
    Vector2 position;
    public float minX = -5.243f;
    public float maxX = 5.253f;
    public float minY = -3.723f;
    public float maxY = 3.755f;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Collider2D>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Collectable");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);

        if (hit.collider == text)
        {
            Debug.Log("Success! Hit " + hit.collider);
        }
        if ((mouse.GetComponent<Collider2D>().IsTouching(text) || (hit.collider == text)) && Input.GetMouseButton(0))
        {
            if (transform.position.x >= minX && transform.position.x <= maxX && transform.position.y >= minY && transform.position.y <= maxY)
            {
                transform.position = mouse.transform.position;
            }
            else
            {
                transform.position = Input.mousePosition;
            }
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
