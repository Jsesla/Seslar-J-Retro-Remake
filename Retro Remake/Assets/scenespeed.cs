using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenespeed : MonoBehaviour
{
    public float gamespeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = gamespeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
