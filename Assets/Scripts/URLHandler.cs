using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class URLHandler : MonoBehaviour
{
    List<string> urlList = new List<string>();
    List<GameObject> websiteList = new List<GameObject>();
    public GameObject Page404;
    public BrowserHistory history;
    public string tempFile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSite(string url, GameObject site)
    {
        urlList.Add(url);
        websiteList.Add(site);
        Debug.Log("Added: " + url + ", " + site);
    }

    public void ChangeSite(string url)
    {
        Debug.Log(url);
        //Debug.Log(history.currentPage);

        bool urlFound = false;
        int urlIndex = 0;
        Debug.Log("input string length: " + url.Length);

        string urlShort = url.Replace("\u200B", "");

        Debug.Log("shortened string length: " + urlShort.Length);

        /*StreamWriter sr = File.CreateText(tempFile);
        sr.WriteLine(url);
        sr.Close();*/

        foreach (string site in urlList)
        {
            //Debug.Log(site.CompareTo(url));
            Debug.Log(site + " length: " + site.Length);

            if (Equals(site, urlShort))
            {
                
                urlFound = true;
                urlIndex = urlList.IndexOf(site);
            }
        }
        
        if (urlFound)
        {
            Debug.Log("Contained Key " + urlShort);
            GameObject page = websiteList[urlIndex];
            history.ChangePage(history.currentPage, page);
            history.history.Push(history.currentPage);
            history.currentPage = page;
        }
        else
        {
            Debug.Log("Didn't contain key " + urlShort);
            GameObject page = Page404;
            history.ChangePage(history.currentPage, page);
            history.history.Push(history.currentPage);
            history.currentPage = page;
        }
    }
}
