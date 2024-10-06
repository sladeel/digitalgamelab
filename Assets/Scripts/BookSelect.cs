using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelect : MonoBehaviour
{
    public CameraController cam;
    public NotepadController pad;
    public NotebookHandler book;
    public FollowMouse mouseActive;
    public PencilController pencil;
    public bool requireClick = false;
    bool click;
    public SpriteRenderer visualBook;
    public Collider2D collide;
    public Collider2D mouse;

    public Collider2D leftCollide;
    public Collider2D rightCollide;
    public Collider2D screenCollide;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Book");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);

        if (requireClick == true)
        {
            click = Input.GetMouseButtonDown(0);
        }
        else
        {
            click = true;
        }

        if (hit.collider != null && book.position != "book")
        {
            visualBook.color = new Color(1, 0.38f, 1, 0.17f);
        }
        else if (book.position != "book")
        {
            visualBook.color = new Color(1, 0.38f, 1, 0);
        }
        else
        {
            visualBook.color = new Color(1, 0.38f, 1, 0.17f);
        }

        if (hit.collider != null && click)
        {
            cam.position = "desk";
            leftCollide.enabled = !leftCollide.enabled;
            rightCollide.enabled = !rightCollide.enabled;
            screenCollide.enabled = !screenCollide.enabled;
            if (book.position != "book")
            {
                book.position = "book";
                pad.position = "book";
                mouseActive.screenActive = false;
                pencil.position = "book";
            }
            else
            {
                book.position = "desk";
                pad.position = "desk";
                mouseActive.screenActive = true;
                pencil.position = "desk";
            }
            
            Debug.Log(hit.collider);
        }
    }
}
