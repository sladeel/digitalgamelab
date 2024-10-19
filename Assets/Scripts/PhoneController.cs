using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public string position;
    private float velocityZoom;
    private Vector3 velocitySpin;
    private Vector3 velocityMove;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;
    float x;
    private Vector3 currentEuler;
    private Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1.57f, -21.3f, 0f);
        transform.localScale = new Vector3(0.59695f, 0.59695f, 0.59695f);
        currentEuler = new Vector3(0, 0, 53.791f);
        currentRotation.eulerAngles = currentEuler;
        transform.rotation = currentRotation;
    }

    // Update is called once per frame
    void Update()
    {

        switch (position)
        {
            case "desk":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(1.57f, -21.3f, 0f), ref velocityMove, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 0.59695f, ref velocityZoom, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);
                currentEuler = Vector3.SmoothDamp(currentEuler, new Vector3(0, 0, 53.791f), ref velocitySpin, smoothTime, maxSpeed);
                currentRotation.eulerAngles = currentEuler;
                transform.rotation = currentRotation;
                break;
            case "phone":
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(5.73f, -0.17f, 0f), ref velocityMove, smoothTime, maxSpeed);
                x = Mathf.SmoothDamp(transform.localScale.x, 1f, ref velocityZoom, smoothTime, maxSpeed);
                transform.localScale = new Vector3(x, x, x);
                currentEuler = Vector3.SmoothDamp(currentEuler, new Vector3(0, 0, -4.421f), ref velocitySpin, smoothTime, maxSpeed);
                currentRotation.eulerAngles = currentEuler;
                transform.rotation = currentRotation;
                break;
        }
    }
}
