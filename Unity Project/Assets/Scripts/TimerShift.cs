using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerShift : MonoBehaviour
{
    
    public float timerMax;
    public GameObject shift;
    public float customTimer = 0;
    bool currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = shift.activeSelf;
        //InvokeRepeating("shiftOn", 0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("shiftOff", timerMax);
        customTimer += Time.deltaTime;

        if(customTimer >= timerMax)
        {
            ShiftState();
            customTimer = 0;
        }

    }

    public void shiftOn()
    {
        shift.SetActive(true);
    }

    public void shiftOff()
    {
        shift.SetActive(false);
    }

    private void ShiftState()
    {
        shift.SetActive(!currentState);
        currentState = !currentState;
    }
}
