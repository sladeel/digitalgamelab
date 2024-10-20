using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    SpriteRenderer button;
    Collider2D collide;
    public Collider2D mouse;
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
        
        if (mouse.IsTouching(collide))
        {
            button.sprite = hover;
        }
        else
        {
            button.sprite = normal;
        }
    }
}
