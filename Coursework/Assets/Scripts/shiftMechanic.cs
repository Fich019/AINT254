using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftMechanic : MonoBehaviour
{
    public GameObject shiftA;
    public GameObject shiftB;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && active == true){
            shiftA.SetActive(true);
            shiftB.SetActive(false);
            active = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && active == false)
        {
            shiftA.SetActive(false);
            shiftB.SetActive(true);
            active = true;
        }
    }
}
