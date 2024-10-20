using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteThis : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void No()
    {
        StartCoroutine(Noo());   
    }

    IEnumerator Noo()
    {
        yield return new WaitForSeconds(1);
        slider.value = 0;
    }

    public void Suicide()
    {
        gameObject.SetActive(false);
    }
}
