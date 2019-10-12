using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 2f;

    public Vector3 jump;
    private float x;
    private GameObject player;
    public bool isGrounded;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpHeight, 0.0f);
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
        x = Input.GetAxis("Horizontal") * speed;
        player.transform.Translate(x, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
