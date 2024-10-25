using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSelect : MonoBehaviour
{
    public FollowMouse mouseActive;
    public bool requireClick = false;
    bool click;
    public SpriteRenderer visualPhone;
    public Collider2D collide;
    public Canvas canvas;
    public PhoneController phone;
    public TextHandler textBox;

    public Collider2D leftCollide;
    public Collider2D rightCollide;
    public Collider2D screenCollide;
    public Collider2D bookCollide;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Phone");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);

        if (requireClick == true)
        {
            click = Input.GetMouseButtonDown(0);
        }
        else
        {
            click = true;
        }

        if (hit.collider != null && !canvas.isActiveAndEnabled) //if hovered over and canvas is disabled
        {
            visualPhone.color = new Color(1, 0.38f, 1, 0.17f);
        }
        else if (canvas.isActiveAndEnabled) //if canvas is enabled
        {
            visualPhone.color = new Color(1, 0.38f, 1, 0);
        }
        else
        {
            visualPhone.color = new Color(1, 0.38f, 1, 0f);
        }

        if ((hit.collider != null) && click && textBox.textReady)
        {
            leftCollide.enabled = false;
            rightCollide.enabled = false;
            screenCollide.enabled = false;
            bookCollide.enabled = false;

            mouseActive.screenActive = false;
            phone.position = "phone";

            canvas.enabled = true;
            

            //Debug.Log(hit.collider);
        }
    }
}

