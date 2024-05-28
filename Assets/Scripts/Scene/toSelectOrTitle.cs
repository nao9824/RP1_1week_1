using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toSelectOrTitle : MonoBehaviour
{
    private int sceneNum;

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            sceneNum = 2;
            Debug.Log(sceneNum);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            sceneNum = 1;
            Debug.Log(sceneNum);
        }

        if (Input.GetKeyDown(KeyCode.Space) && sceneNum==1)
        {
            SceneManager.LoadScene("Select", LoadSceneMode.Single);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && sceneNum == 2)
        {
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        }
    }
}
