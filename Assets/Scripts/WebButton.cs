using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WebButton : MonoBehaviour
{
    public string function;
    public Collider2D mouse;
    public BrowserHistory history;
    Collider2D button;
    public TextMeshProUGUI addressBar;
    public URLHandler url;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.IsTouching(button) && Input.GetMouseButtonDown(0))
        {
            switch (function)
            {
                case "back":
                    history.Back();
                    break;
                case "forwards":
                    history.Forward();
                    break;
                case "home":
                    history.HomePage();
                    break;
                case "refresh":
                    history.RefreshPage();
                    break;
                case "go":
                    //Debug.Log(addressBar.text);
                    url.ChangeSite(addressBar.text);
                    Debug.Log(history.currentPage);
                    break;
            }
        }
    }
}
