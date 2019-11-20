using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private Text curlapText;
    [SerializeField] private Text prevlapText;
    [SerializeField] private Collider lap;

    [SerializeField] private double timer;

    public bool levelComplete;

    // Update is called once per frame
    void Update()
    {
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
        curlapText.text = ts.ToString();
    }

    void lapTimer(double timer)
    {
        TimeSpan ts = TimeSpan.FromSeconds(timer);
        prevlapText.text = ts.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lap")
        {
            levelComplete = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lap")
        {
            levelComplete = false;
        }
    }
}
