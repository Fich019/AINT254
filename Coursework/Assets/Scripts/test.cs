using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class test : MonoBehaviour
{
    public TextMeshProUGUI curlapText;
    public TextMeshProUGUI lapText;
    [SerializeField] private double timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        displayTimer(timer);
    }
    void displayTimer(double _time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(timer);
        int minutes = ts.Minutes;
        int seconds = ts.Seconds;
        int miliseconds = ts.Milliseconds;
        curlapText.text = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }
    public void setLap()
    {
        TimeSpan ts = TimeSpan.FromSeconds(timer);
        int minutes = ts.Minutes;
        int seconds = ts.Seconds;
        int miliseconds = ts.Milliseconds;
        lapText.text = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);

    }
}
