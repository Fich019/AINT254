using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    
    public GameObject player;
    public Movement movement;
    //GameObject [] platform;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public float rayDistance;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //platform = GameObject.FindGameObjectsWithTag("Platform");
        isGrounded = movement.isGrounded;
        Vector3 preHeight = transform.position;

        if (isGrounded == true)
        {
            RaycastHit hit;
            Ray ray = new Ray(player.transform.position, player.transform.up *-1);

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                var hitPlatform = hit.transform;
                Vector3 targetPosition = new Vector3(transform.position.x, (hit.transform.position.y + 2.5f + (hit.transform.localScale.y / 2)), transform.position.z);
                transform.position = Vector3.SmoothDamp(preHeight, targetPosition, ref velocity, smoothTime);
            }

        }
        else
        {
            Vector3 test = new Vector3(player.transform.position.x, preHeight.y, preHeight.z);
            transform.position = Vector3.SmoothDamp(preHeight, test, ref velocity, smoothTime);
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
