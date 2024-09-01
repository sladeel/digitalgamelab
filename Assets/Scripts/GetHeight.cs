using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeight : MonoBehaviour
{
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
