using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    
    public GameObject raycam;
    public float rayDistance = 100;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        raycam.transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GetComponent<Movement>().isGrounded;

        if (isGrounded == true)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, -transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                var hitPlatform = hit.transform;
                raycam.transform.position = new Vector3(raycam.transform.position.x, hit.transform.position.y + 2.5f + (hit.transform.localScale.y / 2), raycam.transform.position.z);
            }

        }
        else
        {
            Vector3 preHeight = raycam.transform.position;
            raycam.transform.position = preHeight;
        }

        //if (Physics.Raycast(transform.position, transform.TransformDirection(-transform.up), out ray, rayDistance))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(-transform.up) * ray.distance, Color.yellow);
        //    if (ray.transform.tag == "Platform")
        //    {
        //        Debug.Log(ray.point);
        //    }
        //}

        
    }
    
}
