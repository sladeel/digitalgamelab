using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillButton : MonoBehaviour
{
    public string scene;
    public List<GameObject> madlibsItems;
    
    public MadlibsItem subject1;
    public MadlibsItem weapon2;
    public MadlibsItem location2;
    public MadlibsItem verb3;
    public MadlibsItem noun3;
    public MadlibsItem verb4;
    public MadlibsItem noun4;
    public MadlibsItem code4;
    public MadlibsItem location5;
    public MadlibsItem time5;
    public MadlibsItem verb6;
    public MadlibsItem noun6a;
    public MadlibsItem noun6b;
    public MadlibsItem verb7;
    public MadlibsItem noun7;

    

    
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
