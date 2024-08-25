using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minX = -5.243f;
    public float maxX = 5.253f;
    public float minY = -3.723f;
    public float maxY = 3.755f;


    Vector2 currentVelocity;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if ((transform.position.x >= minX && transform.position.x <= maxX && transform.position.y >= minY && transform.position.y <= maxY) || (mousePosition.x >= minX && mousePosition.x <= maxX && mousePosition.y >= minY && mousePosition.y <= maxY))
            {
            transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        
        
        
        
    }
}

