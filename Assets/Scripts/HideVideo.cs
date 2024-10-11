using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HideVideo : MonoBehaviour
{
    VideoPlayer video;
    public float videoTime;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        videoTime = (float)video.length;
        Invoke("videoEnded", videoTime);
    }

    void videoEnded()
    {
        gameObject.SetActive(false);
        canvas.SetActive(true);
    }
}
