using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartScene : MonoBehaviour
{
    public GameObject player;
    public GameObject timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision hit)
    {

        //Restarts the scene using a checkpoint system by getting the players 
        //current position when they have collided with a checkpointable platform and storing
        //it in a varable.
        Vector3 Checkpoint = player.GetComponent<Movement>().Checkpoint;

        if (hit.gameObject.tag == "Player")
        {
            timer.GetComponent<test>().timer = 0;
            player.transform.position = Checkpoint;
        }
    }
}
