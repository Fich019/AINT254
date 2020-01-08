using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    private float startspeed;
    public float jumpVel;

    public float slideSpeed;
    private float slideTimer = 0f;
    public float slideTimerMax;
    private Vector3 direction;

    public float fallMultiplier;
    public string main;

    public Vector3 jump;
    //private float x;
    private GameObject player;

    public bool isGrounded;
    public bool isSliding;
    Rigidbody rb;
    public Vector3 Checkpoint;
    public GameObject timer;


    // Start is called before the first frame update
    void Start()
    {
        startspeed = speed;
        player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        //main = SceneManager.GetActiveScene().name;
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
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            //rb.AddForce(Vector3.up * jumpVel, ForceMode.Impulse);
            rb.velocity = Vector3.up * jumpVel; //jumpvel = 21
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded == true && !isSliding)
        {
            slideTimer = 0;
            isSliding = true;
        }
        if (isSliding == true)
        {
            speed = slideSpeed;
            rb.AddForce(direction * speed, ForceMode.Impulse);
            transform.localScale = new Vector3(1.5f,0.75f,1f);
            transform.position = new Vector3(transform.position.x, 0.75f, 0);

            slideTimer += Time.deltaTime;
            if (slideTimer > slideTimerMax)
            {
                isSliding = false;
                speed = startspeed;
                transform.localScale = new Vector3(1.5f, 1.5f, 1f);

                //https://answers.unity.com/questions/374157/character-controller-slide-action-script.html
            }
        }
        //x = Input.GetAxis("Horizontal") * speed;

        //if (Input.GetKey(KeyCode.D)){
        //    player.transform.Translate(speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.A)){
        //    player.transform.Translate(-speed, 0, 0);
        //}


        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
        //    rb.velocity = Vector3.up * jumpVel;
        //    isGrounded = false;
        //}

        //if (rb.velocity.y < 0)
        //{
        //    rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}

    }

    private void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(speed, 0, 0);
            direction = Vector3.right;

        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-speed, 0, 0);
            direction = Vector3.left;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            timer.GetComponent<test>().timer = 0;
            player.transform.position = Checkpoint;
        }

        //if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        //{
        //    //rb.AddForce(Vector3.up * jumpVel, ForceMode.Impulse);
        //    rb.velocity = Vector3.up * jumpVel; //jumpvel = 21
        //    isGrounded = false;
        //}

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
    }

    private void sMov()
    {
        rb.AddForce(Vector3.left * -slideSpeed, ForceMode.Impulse);
        rb.AddForce(Vector3.right * -slideSpeed, ForceMode.Impulse);
        print("memes");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            Checkpoint = player.transform.position;
        }
    }
}
