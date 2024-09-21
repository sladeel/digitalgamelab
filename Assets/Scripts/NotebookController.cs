using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    public string position;
    private Vector3 velocityBook;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;
    public float speed = 3;

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
                transform.localScale = Vector3.Slerp(transform.localScale, new Vector3(0.5437f, 0.5437f, 0.5437f), speed * Time.deltaTime);

                break;
            case "desk":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -20f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                transform.localScale = Vector3.Slerp(transform.localScale, new Vector3(0.5437f, 0.5437f, 0.5437f), speed * Time.deltaTime);
                
                break;
            case "book":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -0.53f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                transform.localScale = Vector3.Slerp(transform.position, new Vector3(1f, 1f, 1f), speed * Time.deltaTime);

                break;
        }
    }
}
