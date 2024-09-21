using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public SpriteRenderer button;
    public BoxCollider2D collide;
    public Collider2D mouse;
    public Sprite normal;
    public Sprite hover;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<SpriteRenderer>();
        collide = GetComponent<BoxCollider2D>();

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
