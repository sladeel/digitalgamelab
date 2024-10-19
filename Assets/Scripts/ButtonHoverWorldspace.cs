using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverWorldspace : MonoBehaviour
{
    SpriteRenderer button;
    Collider2D collide;
    public Sprite normal;
    public Sprite hover;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<SpriteRenderer>();
        collide = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Hover");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);

        if (hit == collide)
        {
            button.sprite = hover;
        }
        else
        {
            button.sprite = normal;
        }
    }
}
