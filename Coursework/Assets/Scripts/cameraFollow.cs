using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //Camera horizontal, fov = 35, distance = 55, height = 2.5
    public Transform player;
    public float distance, height;
    public float xMin, xMax;
    public float yMin, yMax;
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
        float x = Mathf.Clamp(player.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.position.y, yMin, yMax);

        transform.position = new Vector3(x, y + 1f, -distance);
    }
}
