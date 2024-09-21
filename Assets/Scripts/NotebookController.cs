using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    public string position;
    private Vector3 velocityBook;
    private float velocityScale;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;
    public float speed = 3;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (position)
        {
            case "screen":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -8.08f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 0.5437f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
            case "desk":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -20f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 0.5437f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
            case "book":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -0.53f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 1.0424f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
        }
    }
}
