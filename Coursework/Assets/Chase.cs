using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = player.GetComponent<Movement>().isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float newHeight = player.transform.position.y;
        isGrounded = player.GetComponent<Movement>().isGrounded;

        //if (player.transform.position.y > 1.5 && isGrounded == true)
        //{

        //    //if (Input.GetKey(KeyCode.Space))
        //    //{
        //    //    transform.position = new Vector3(player.transform.position.x, newHeight, 0);
        //    //}
        //    //else
        //    //{
        //    //    transform.position = new Vector3(player.transform.position.x, newHeight, 0);
        //    //}

        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        transform.position = new Vector3(player.transform.position.x, newHeight, 0);
        //    }
        //    else
        //    {
        //        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        //    }
        //}
        //else if (player.transform.position.y == 1.5f && isGrounded == true)
        //{
        //    transform.position = new Vector3(player.transform.position.x, 1.5f, 0);
        //}


        transform.position = new Vector3(player.transform.position.x, newHeight, 0);



    }

        
}
