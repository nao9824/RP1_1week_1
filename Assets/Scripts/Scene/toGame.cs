using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    private int stageNum;

    // Start is called before the first frame update
    void Start()
    {
        stageNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SelectStage();

        
    }

    private void SelectStage()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
           stageNum++;
            if(stageNum >= 5) {
                stageNum = 5;
            }
            Debug.Log(stageNum);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            stageNum--;
            if (stageNum <= 1)
            {
                stageNum = 1;
            }
            Debug.Log(stageNum);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

}
