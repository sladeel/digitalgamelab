using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string position;
    public Camera cam;
    private float velocityZoom;
    private Vector3 velocityMove;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;



    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = 10.8f;
        transform.position = new Vector3(0, -1.21f, -10);
    }

    // Update is called once per frame
    void Update()
    {

        switch (position)
        {
            case "screen":
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 5, ref velocityZoom, smoothTime, maxSpeed);
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, 0, -10), ref velocityMove, smoothTime, maxSpeed);

                break;
            case "desk":
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 10.8f, ref velocityZoom, smoothTime, maxSpeed);
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, -1.21f, -10), ref velocityMove, smoothTime, maxSpeed);

                break;
        }
    }
}

