using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageTest : MonoBehaviour
{
    private Transform m_transform;
    public GameObject prefab;
    private GameObject[] m_array;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
        m_array = new GameObject[1000];

        for (int i = 0; i < m_array.Length; i++)
        {
            //m_array.SetValue(prefab, i);

            GameObject tempObject = Instantiate(prefab);
            m_array[i] = tempObject;
            m_array[i].SetActive(false);
        }
    }

    void TransformTest()
    {
        for (int i = 0; i < 10000; i++)
        {
            m_transform.position = Vector3.zero;
        }

    }

    void ObjectAllocation()
    {
        

        for (int i = 0; i < 1000; i++)
        {
            int j = 1;
            j++;
            int k = j;

            complexObject tempObject = new complexObject();
        }

    }

    void OptimisedInstantiateTest()
    {
        for (int i = 0; i < m_array.Length; i++)
        {
            m_array[i].SetActive(true);
            m_array[i].transform.position = new Vector3(1, 0, 0);
            m_array[i].SetActive(false); //Keeps the memory clear 
        }
    }

    void InstantiateTest()
    {
        for (int i = 0; i < 1000; i++)
        {
            GameObject tempObject = Instantiate(prefab);
            tempObject.transform.position = new Vector3(1, 0, 0);
            Destroy(tempObject); //Keeps the memory clear 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //TransformTest();
        //ObjectAllocation();
        //InstantiateTest();
        OptimisedInstantiateTest();
    }
}
