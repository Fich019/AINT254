using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpVel = 2f;

    public float fallMultiplier = 3.5f;

    //public Vector3 jump;
    //private float x;
    private GameObject player;
    public bool isGrounded;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, jumpVel, 0.0f);
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {
        isGrounded = false;
    }


    // Update is called once per frame
    void Update()
    {
        //x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.D)){
            player.transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)){
            player.transform.Translate(-speed, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            rb.velocity = Vector3.up * jumpVel;
            isGrounded = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }
}
