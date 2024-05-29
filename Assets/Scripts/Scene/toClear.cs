using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (collision.gameObject.CompareTag("Clear"))
        {
            Debug.Log("Clear");
            SceneManager.LoadScene("Clear", LoadSceneMode.Single);
        }*/

        /* if (Input.GetKeyDown(KeyCode.C))
         {
             SceneManager.LoadScene("Clear", LoadSceneMode.Single);
         }*/
    }

}
