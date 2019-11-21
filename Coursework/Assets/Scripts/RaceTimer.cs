using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RaceTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private TextMeshProUGUI curlapText;
    [SerializeField] private TextMeshProUGUI prevlapText;

    [SerializeField] private double timer;

    public newLap lap;

    // Update is called once per frame
    void Update()
    {
        bool levelComplete = lap.levelComplete;

        timer += Time.deltaTime;

        if (levelComplete == true)
        {
            lapTimer(timer);
        }
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

    void lapTimer(double timer)
    {
        TimeSpan ts = TimeSpan.FromSeconds(timer);
        int minutes = ts.Minutes;
        int seconds = ts.Seconds;
        int miliseconds = ts.Milliseconds;
        prevlapText.text = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }
}
