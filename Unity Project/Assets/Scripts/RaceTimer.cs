using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceTimer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI curlapText;
    [SerializeField] private TextMeshProUGUI prevlapText;
    [SerializeField] private GameObject player;

    [SerializeField] private double timer = 0;
    private bool[] Laps;
    int i = 0;

    public newLap lap;
    // Start is called before the first frame update
    void Start()
    {
        Laps = new bool[2];
    }


    // Update is called once per frame
    void Update()
    {
        Laps[0] = player.GetComponent<newLap>().levelComplete;
        Laps[1] = player.GetComponent<lap2>().levelComplete;

        bool levelComplete = Laps[i];

        timer += Time.deltaTime;

        if (levelComplete == true)
        {

            lapTimer(timer);
            i++;
            levelComplete = Laps[i];
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
