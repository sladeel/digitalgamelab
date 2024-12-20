using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookHandler : MonoBehaviour
{
    public string position;
    private Vector3 velocityBook;
    private Vector3 velocitySpin;
    private float velocityScale;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;
    public float speed = 3;
    private float x;
    private Vector3 currentEuler;
    private Quaternion currentRotation;
    
    public int page;
    public int length;

    public GameObject grabbed;

    // Start is called before the first frame update
    void Start()
    {
        page = 1;
        transform.position = new Vector3(-0.26f, -20f, -5.98f);
        transform.localScale = new Vector3(0.5437f, 0.5437f, 0.5437f);
    }

    // Update is called once per frame
    void Update()
    {
        switch (position)
        {
            case "screen":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -20f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 0.5437f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
            case "desk":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-0.26f, -20f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 0.5437f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
            case "book":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(3.53f, -0.23f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                currentEuler = Vector3.SmoothDamp(currentEuler, new Vector3(0, 0, -0.847f), ref velocitySpin, smoothTime, maxSpeed);
                currentRotation.eulerAngles = currentEuler;
                transform.rotation = currentRotation;
                x = Mathf.SmoothDamp(transform.localScale.x, 1.123499f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
        }

        if (Input.GetMouseButtonUp(0))
        {
            grabbed = null;
        }
    }
}
