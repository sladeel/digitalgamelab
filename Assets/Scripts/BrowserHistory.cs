using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserHistory : MonoBehaviour
{
    public Stack<GameObject> history;
    public Stack<GameObject> future;
    public GameObject currentPage;
    
    // Start is called before the first frame update
    void Start()
    {
        history = new Stack<GameObject>();
        future = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPage(GameObject page)
    {
        history.Push(currentPage);
        currentPage = page;
        future.Clear();
    }

    public void Back()
    {
        if (history.Count != 0)
        {
            GameObject page = history.Pop();
            ChangePage(currentPage, page);
            future.Push(currentPage);
            currentPage = page;
        }
        
    }

    public void Forward()
    {
        if (future.Count != 0)
        {
            GameObject page = future.Pop();
            ChangePage(currentPage, page);
            history.Push(currentPage);
            currentPage = page;
        }
    }

    public void ChangePage(GameObject current, GameObject next)
    {
        GameObject CurrentBg = current.transform.parent.gameObject;
        GameObject NextBg = next.transform.parent.gameObject;

        current.SetActive(false);
        next.SetActive(true);

        if (CurrentBg != NextBg)
        {
            CurrentBg.SetActive(false);
            NextBg.SetActive(true);
        }
    }
}