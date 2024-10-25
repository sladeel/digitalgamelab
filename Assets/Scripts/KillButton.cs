using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillButton : MonoBehaviour
{
    public string scene;
    public List<GameObject> madlibsItems;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Hover");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
