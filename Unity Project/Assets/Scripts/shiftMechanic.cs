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
        //disables the platforms that are currently active and enables ones hidden.
        if (Input.GetKeyDown(KeyCode.LeftShift) && active == true){
            shiftA.SetActive(true);
            shiftB.SetActive(false);
            active = false;
        }

        //does the reverse of the code above.
        else if (Input.GetKeyDown(KeyCode.LeftShift) && active == false)
        {
            shiftA.SetActive(false);
            shiftB.SetActive(true);
            active = true;
        }
    }
}
