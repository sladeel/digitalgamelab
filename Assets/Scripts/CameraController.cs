using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string position;
    public Camera cam;
    private float velocityZoom;
    private Vector3 velocityMove;
    private Vector3 velocityBook;
    public float smoothTime = 0.3f;
    public float maxSpeed = 10;
    public GameObject notebook;



    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(position)
        {
            case "screen":
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 5, ref velocityZoom, smoothTime, maxSpeed);
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, 0, -10), ref velocityMove, smoothTime, maxSpeed);

                notebook.transform.position = Vector3.SmoothDamp(notebook.transform.position, new Vector3(-0.26f, -8.08f, -5.98f), ref velocityBook, smoothTime, maxSpeed);

                break;
            case "desk":
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 10, ref velocityZoom, smoothTime, maxSpeed);
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, -1.15f, -10), ref velocityMove, smoothTime, maxSpeed);

                notebook.transform.position = Vector3.SmoothDamp(notebook.transform.position, new Vector3(-0.26f, -16.32f, -5.98f), ref velocityBook, smoothTime, maxSpeed);
                break;
        }
    }
}
