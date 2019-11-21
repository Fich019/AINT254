using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour
{
    
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
        string main = SceneManager.GetActiveScene().name;

        
        if (hit.transform.tag == "Player")
        {
            SceneManager.LoadScene(main, LoadSceneMode.Single);
            //print("memes");
        }
    }
}
