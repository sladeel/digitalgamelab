using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    
    public CameraController cam;
    public bool requireClick = false;
    bool click;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Zoom In");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);
            

        if (requireClick == true)
        {
            click = Input.GetMouseButtonDown(0);
        }
        else
        {
            click = true;
        }

        if (hit.collider != null && click)
        {
            cam.position = "screen";
            Debug.Log(hit.collider);
        }
    }
}
