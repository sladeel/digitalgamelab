using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageGraphics : MonoBehaviour
{

    Renderer graphicRenderer;
    public NotebookHandler notebookHandler;
    public Collider2D hitbox;
    public int page;

    // Start is called before the first frame update
    void Start()
    {
        graphicRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notebookHandler.page == page)
        {
            if (graphicRenderer.enabled == false)
            {
                graphicRenderer.enabled = !graphicRenderer.enabled;
                if (hitbox != null)
                {
                    hitbox.enabled = !hitbox.enabled;
                }
            }
            
        }
        else
        {
            if (graphicRenderer.enabled == true)
            {
                graphicRenderer.enabled = !graphicRenderer.enabled;
                if (hitbox != null)
                {
                    hitbox.enabled = !hitbox.enabled;
                }
            }
        }
    }
}
