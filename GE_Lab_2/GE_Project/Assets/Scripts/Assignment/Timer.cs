using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  private float startTime;
   static public bool theEnd = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (theEnd)
            return;


        float t = Time.time - startTime;

        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");
        if(float.Parse(sec) < 10)
        {
            sec = "0" + sec;
        }
        this.GetComponent<Text>().text = min + ":" + sec;


    }
}
