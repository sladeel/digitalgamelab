using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilController : MonoBehaviour
{
    public string position;
    private Vector3 velocityPencil;
    private Vector3 velocitySpin;
    private float velocityScale;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;
    public float speed = 3;
    private float x;
    private Vector3 currentEuler;
    private Quaternion currentRotation;


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
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(7.44f, -6.55f, 0f), ref velocityPencil, smoothTime, maxSpeed);
                currentEuler = Vector3.SmoothDamp(currentEuler, new Vector3(0, 0, 27.001f), ref velocitySpin, smoothTime, maxSpeed);
                currentRotation.eulerAngles = currentEuler;
                transform.rotation = currentRotation;
                x = Mathf.SmoothDamp(transform.localScale.x, 1.4525f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
            case "desk":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(6.57f, -15.93f, 0f), ref velocityPencil, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 1.4525f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
            case "book":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(6.57f, -15.93f, 0f), ref velocityPencil, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 1.4525f, ref velocityScale, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);

                break;
        }
    }
}
