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
    public bool isGrounded;

    

    private static int platCount = 1;


    public float rayDistance, distance, height;
    public float xMin, xMax;


    public static Vector3 curPlatform;
    //public float yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //platform = GameObject.FindGameObjectsWithTag("Platform");
        isGrounded = movement.isGrounded;
        Vector3 preHeight = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        //Checks if the player is grounded, if they are, send a raycast out the platform that they are currently
        //on and store it as a variable. Then create a vector 3 with the data stored from the raycast and have the
        //camera move the this new position via smoothdamp.
        if (isGrounded == true)
        {
            RaycastHit hit;
            Ray ray = new Ray(player.transform.position, player.transform.up * -1);

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                var hitPlatform = hit.transform;
                Vector3 targetPosition = new Vector3(transform.position.x, (hit.transform.position.y + height + (hit.transform.localScale.y / 2)), transform.position.z);
                transform.position = Vector3.SmoothDamp(preHeight, targetPosition, ref velocity, smoothTime);
                curPlatform = player.transform.position;
            }

        }
        //This else statement will stop the camera from moving if the player is in the air, keeping the 
        //camera in a fixed y and z position during airtime. It will follow the player along the x axis however

        else
        {
            Vector3 test = new Vector3(player.transform.position.x, preHeight.y, preHeight.z);
            transform.position = Vector3.SmoothDamp(preHeight, test, ref velocity, smoothTime);
            curPlatform = player.transform.position;
        }


        //Moves the camera below the current platform. Other code that is commented out work but not with the way I have set up the 
        //shift mechanic and so without reworking the game from the ground up had to be left unused.
        if (Input.GetKey(KeyCode.S))
        {

            //Vector3 helpPos = new Vector3(GameObject.FindWithTag(platCount.ToString()).transform.position.x, GameObject.FindWithTag(platCount.ToString()).transform.position.y, transform.position.z);
            //if (isGrounded == true && player.GetComponent<Collider>().
            //{
            //    platCount++;
            //    Debug.Log(platCount);
            //    helpPos = new Vector3(GameObject.FindWithTag(platCount.ToString()).transform.position.x, GameObject.FindWithTag(platCount.ToString()).transform.position.y, transform.position.z);
            //}
            //else
            //{
            //    transform.position = Vector3.SmoothDamp(preHeight, helpPos, ref velocity, smoothTime);
            //}
            Vector3 helpPos = new Vector3(transform.position.x, transform.position.y - height * 2, transform.position.z);
            transform.position = Vector3.SmoothDamp(preHeight, helpPos, ref velocity, smoothTime);
        }
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        //float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        Vector3 tPosition = new Vector3(x, transform.position.y, -distance); //playergame.GetComponent<Raycast>().raycam.transform.position.y
        Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(origin, tPosition, ref velocity, smoothTime);



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
