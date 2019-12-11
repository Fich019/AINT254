using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerShift : MonoBehaviour
{
    
    public float timerMax;
    public GameObject shift;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shiftOn", 0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("shiftOff", timerMax);
    }

    public void shiftOn()
    {
        shift.SetActive(true);
    }

    public void shiftOff()
    {
        shift.SetActive(false);
    }
}
