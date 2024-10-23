using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordHandler : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField pass;

    public string[] users;
    public string[] passes;
    public GameObject[] webpages;

    public Collider2D mouse;
    Collider2D button;
    public BrowserHistory history;
    public GameObject CurrentPage;
    public TextMeshProUGUI addressBar;
    bool wrongPass;
    public GameObject passWarning;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Collider2D>();
        wrongPass = false;
    }

    void OnEnable()
    {
        passWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.IsTouching(button) && Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < users.Length; i++)
            {
                wrongPass = true;
                if (user.text == users[i] && pass.text == passes[i])
                {
                    history.NewPage(webpages[i]);
                    CurrentPage.SetActive(false);
                    webpages[i].SetActive(true);
                    addressBar.text = webpages[i].GetComponent<Website>().url;

                    if (webpages[i].GetComponent<Scroll>() != null)
                    {
                        webpages[i].transform.position = new Vector2(webpages[i].transform.position.x, webpages[i].GetComponent<Scroll>().StartPosition);
                    }


                    if (CurrentPage.transform.parent.gameObject != webpages[i].transform.parent.gameObject)
                    {
                        CurrentPage.transform.parent.gameObject.SetActive(false);
                        webpages[i].transform.parent.gameObject.SetActive(true);
                    }
                    wrongPass = false;
                }
            }
            if (wrongPass)
            {
                passWarning.SetActive(true);
            }
        }
    }
}
