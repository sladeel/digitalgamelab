using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionHandler : MonoBehaviour
{

    public SpriteRenderer character;
    public Sprite annoyed;
    public Sprite concerned;
    public Sprite confused;
    public Sprite defeated;
    public Sprite grrr;
    public Sprite happy;
    public Sprite normal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Express(string expression)
    {
        //Debug.Log(expression);
        if (expression == "NULL")
        {
            if (character.enabled == true)
            {
                character.enabled = !character.enabled;
            }
        }
        else
        {
            if (character.enabled != true)
            {
                character.enabled = !character.enabled;
            }


            switch (expression)
            {
                case "annoyed":
                    character.sprite = annoyed;
                //Debug.Log(character.sprite + " annoyed");
                    break;
                case "concerned":
                    character.sprite = concerned;
                //Debug.Log(character.sprite + " concerned");
                break;
                case "confused":
                    character.sprite = confused;
                //Debug.Log(character.sprite + " confused");
                break;
                case "defeated":
                    character.sprite = defeated;
                //Debug.Log(character.sprite + " defeated");
                break;
                case "grrr":
                    character.sprite = grrr;
                //Debug.Log(character.sprite + " grrr");
                break;
                case "happy":
                    character.sprite = happy;
                //Debug.Log(character.sprite + " happy");
                break;
                case "normal":
                    character.sprite = normal;
                //Debug.Log(character.sprite + " normal");
                break;
            default:
                //Debug.Log(character.sprite + " default");
                break;

            }
        }
    }
}
