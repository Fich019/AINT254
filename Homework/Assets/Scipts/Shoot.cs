using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float moveSpeed = 100.0f;

    public GameObject Spawn;
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Instantiate(Prefab);
            Prefab.transform.position = Spawn.transform.position;
            //Prefab.transform.rotation.y = Prefab.transform.rotation.y + 90;
        }
    }
}
