using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillButton : MonoBehaviour
{
    public string scene;
    public List<GameObject> madlibsItems;
    
    public MadlibsItem subject1Item;
    public MadlibsItem weapon2Item;
    public MadlibsItem location2Item;
    public MadlibsItem verb3Item;
    public MadlibsItem noun3Item;
    public MadlibsItem verb4Item;
    public MadlibsItem noun4Item;
    public MadlibsItem code4Item;
    public MadlibsItem location5Item;
    public MadlibsItem time5Item;
    public MadlibsItem verb6Item;
    public MadlibsItem noun6aItem;
    public MadlibsItem noun6bItem;
    public MadlibsItem verb7Item;
    public MadlibsItem noun7Item;

    public string subject1;
    public string weapon2;
    public string location2;
    public string verb3;
    public string noun3;
    public string verb4;
    public string noun4;
    public string code4;
    public string location5;
    public string time5;
    public string verb6;
    public string noun6a;
    public string noun6b;
    public string verb7;
    public string noun7;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            subject1 = subject1Item.currentItem;
            weapon2 = weapon2Item.currentItem;
            location2 = location2Item.currentItem;
            verb3 = verb3Item.currentItem;
            noun3 = noun3Item.currentItem;
            verb4 = verb4Item.currentItem;
            noun4 = noun4Item.currentItem;
            code4 = code4Item.currentItem;
            location5 = location5Item.currentItem;
            time5 = time5Item.currentItem;
            verb6 = verb6Item.currentItem;
            noun6a = noun6aItem.currentItem;
            noun6b = noun6bItem.currentItem;
            verb7 = verb7Item.currentItem;
            noun7 = noun7Item.currentItem;
        }
        catch
        {
            
        }
        LayerMask mask = LayerMask.GetMask("Hover");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, mask);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            
            //SceneManager.LoadScene(scene);
        }
    }


    void KillCheck()
    {
        bool cameras = (verb4 == "disable" && noun4 == "cameras" && code4 == "camera access code");
        
        switch (subject1)
        {
            case null:
                //Failed Kill Success
                break;
            case "Alice Van Dyke":
                //Alice Kill
                break;
            case "Robin Baker":
                if ((weapon2 == "brick" && (location2 == "roof" || location2 == "stairwell"))|| weapon2 == "flowerpot" && location2 == "roof")
                {
                    if ((location5 == "roof") && (verb6 == "drop") && (noun6b == "Robin Baker") && (noun6a == weapon2))
                    {
                        if ((time5 == "915am") || (time5 == "1230pm") || (time5 == "5pm"))
                        {
                            //Robin kill success, check if coverup success
                            if (cameras && (verb3 == "use") && (noun3 == "gloves"))
                            {
                                //robin kill success, coverup success
                            }
                            else
                            {
                                //robin kill success, caught
                            }
                        }
                    }
                }
                else
                {
                    
                }
                break;
        }

        
    }
}
