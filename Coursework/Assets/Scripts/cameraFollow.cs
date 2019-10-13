using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
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
        float x = Mathf.Clamp(player.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.position.y, yMin, yMax);

        transform.position = new Vector3(x, height, -distance);

    }
}
