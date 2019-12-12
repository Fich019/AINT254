using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbraod : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timer;
    private GameObject test;
    void Start()
    {
        test = timer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   

    private void OnTriggerExit(Collider other)
    {
        test.GetComponent<test>().setLap();
    }
}
