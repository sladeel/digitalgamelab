using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnClick : MonoBehaviour
{
    SpriteRenderer render;
    public Sprite normal;
    public Sprite changeto;
    public Collider2D mouse;
    Collider2D button;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        button = GetComponent<Collider2D>();
        render.sprite = normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.IsTouching(button) && Input.GetMouseButtonDown(0))
        {
            render.sprite = changeto;
        }
    }
}
