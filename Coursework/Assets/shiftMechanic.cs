using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftMechanic : MonoBehaviour
{
    GameObject shift;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        shift.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && active == true){
            shift.SetActive(false);
            active = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && active == false)
        {
            shift.SetActive(true);
            active = true;
        }
    }
}
