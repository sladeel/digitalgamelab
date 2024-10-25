using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillButton : MonoBehaviour
{
    public string scene;
    public List<GameObject> madlibsItems;
    public MurderHandler murder;
    
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

    string subject1;
    string weapon2;
    string location2;
    string verb3;
    string noun3;
    string verb4;
    string noun4;
    string code4;
    string location5;
    string time5;
    string verb6;
    string noun6a;
    string noun6b;
    string verb7;
    string noun7;

    public enum endingType
        {
        AliceKill,
        ChelseaCaught,
        ChelseaSuccess,
        WrongCaught,
        WrongSuccess,
        FailCaught,
        NetZero
        }
    
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
            murder.ending = KillCheck();

            switch (subject1)
            {
                case "Chelsea Young":
                    murder.victim = "Chelsea";
                    murder.pronoun = "her";
                    break;
                case "Robin Baker":
                    murder.victim = "Robin";
                    murder.pronoun = "them";
                    break;
                case "Daniel Foster":
                    murder.victim = "Daniel";
                    murder.pronoun = "him";
                    break;
                case "Janice Johnson":
                    murder.victim = "Janice";
                    murder.pronoun = "her";
                    break;
                case "Chadwick Bones":
                    murder.victim = "Chad";
                    murder.pronoun = "him";
                    break;
            }
            SceneManager.LoadScene(scene);
        }
    }


    endingType KillCheck()
    {
        if (subject1 == "Alice Van Dyke")
        {
            return endingType.AliceKill;
        }
        else if (subject1 == null)
        {
            return endingType.NetZero;
        }

        bool kill = false;
        bool coverup = false;
        
        bool cameras = (verb4 == "disable") && (noun4 == "cameras") && (code4 == "camera access code");
        bool gloves = (verb3 == "use") && (noun3 == "gloves");
        string method;
        string victim;

        coverup = (cameras && gloves);

        switch (weapon2)
        {
            case "knife":
                method = "knife";
                break;
            case "hitman":
                method = "hitman";
                break;
            case "brick":
                method = "drop";
                break;
            case "flowerpot":
                method = "drop";
                break;
            case "ricin":
                method = "poison";
                break;
            case "digitalis":
                method = "poison";
                break;
            case "botulinum":
                method = "poison";
                break;
            case "succinylcholine":
                method = "poison";
                break;
            case "peanut":
                method = "poison";
                break;
            default:
                method = "push";
                break;

        }

        victim = subject1;
        if (victim == "robin username")
        {
            victim = "Robin Baker";
        }

        if ((victim == "Chelsea Young") && (method == "knife") && (location2 == "kitchen") && (location5 == "stairwell") && (time5 == "10am"))
        {
            kill = true;
        }
        else if ((victim == "Chelsea Young") && (method == "knife") && (location2 == "freeknife4u") && (location5 == "stairwell") && (time5 == "10am"))
        {
            kill = true;
        }
        else if ((victim == "Chelsea Young") && (method == "hitman") && (location2 == "hitman4hire") && (location5 == "stairwell") && (time5 == "10am"))
        {
            kill = true;
        }
        else if ((victim == "Chelsea Young") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "9am"))
        {
            kill = true;
        }
        else if ((victim == "Chelsea Young") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Chelsea Young") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "9am"))
        {
            kill = true;
        }
        else if ((victim == "Chelsea Young") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "poison") && (location2 == "poisoninurcup") && (location5 == "*") && (time5 == "*"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "fall") && (location2 == "*") && (location5 == "roof") && (time5 == "430pm"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "fall") && (location2 == "*") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "12pm"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "12pm"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "8pm"))
        {
            kill = true;
        }
        else if ((victim == "Janice Johnson") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "8pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "knife") && (location2 == "kitchen") && (location5 == "Gym") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "knife") && (location2 == "freeknife4u") && (location5 == "Gym") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "knife") && (location2 == "kitchen") && (location5 == "Gym") && (time5 == "630pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "knife") && (location2 == "freeknife4u") && (location5 == "Gym") && (time5 == "630pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "hitman") && (location2 == "hitman4hire") && (location5 == "Gym") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "hitman") && (location2 == "hitman4hire") && (location5 == "Gym") && (time5 == "630pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "830am"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "830am"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Chadwick Bones") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Daniel Foster") && (method == "fall") && (location2 == "*") && (location5 == "roof") && (time5 == "230pm"))
        {
            kill = true;
        }
        else if ((victim == "Daniel Foster") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "9am"))
        {
            kill = true;
        }
        else if ((victim == "Daniel Foster") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "9am"))
        {
            kill = true;
        }
        else if ((victim == "Daniel Foster") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Daniel Foster") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Robin Baker") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "915am"))
        {
            kill = true;
        }
        else if ((victim == "Robin Baker") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "915am"))
        {
            kill = true;
        }
        else if ((victim == "Robin Baker") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "1230pm"))
        {
            kill = true;
        }
        else if ((victim == "Robin Baker") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "1230pm"))
        {
            kill = true;
        }
        else if ((victim == "Robin Baker") && (method == "drop") && (location2 == "roof") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }
        else if ((victim == "Robin Baker") && (method == "drop") && (location2 == "stairwell") && (location5 == "roof") && (time5 == "5pm"))
        {
            kill = true;
        }

        if ((method == "hitman") && kill)
        {
            if ((verb7 == "send") && (noun7 == "plan"))
            {
                kill = true;
            } 
            else
            {
                kill = false;
            }
        }

        if (coverup && method == "fall")
        {
            if ((verb7 == "confirm") && (noun7 == "death"))
            {
                coverup = true;
            }
            else
            {
                coverup = false;
            }
        }
        else if (coverup && method == "knife")
        {
            if ((verb7 == "hide") && (noun7 == "knife"))
            {
                coverup = true;
            }
            else if ((verb7 == "hide") && (noun7 == "clothes"))
            {
                coverup = true;
            }
            else if ((verb7 == "burn") && (noun7 == "clothes"))
            {
                coverup = true;
            }
            else
            {
                coverup = false;
            }
        }

        if ((victim == "Chelsea Young") && coverup && kill)
        {
            return endingType.ChelseaSuccess;
        }
        else if ((victim == "Chelsea Young") && kill)
        {
            return endingType.ChelseaCaught;
        }
        else if (kill && coverup)
        {
            return endingType.WrongSuccess;
        }
        else if (kill)
        {
            return endingType.WrongCaught;
        }
        else if (coverup)
        {
            return endingType.NetZero;
        }
        else
        {
            return endingType.FailCaught;
        }

    }
}
