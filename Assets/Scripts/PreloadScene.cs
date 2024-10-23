using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScene : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        AsyncOperation preloader = SceneManager.LoadSceneAsync(scene);
        preloader.allowSceneActivation = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
