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

        if (Input.GetKeyDown(KeyCode.Space) && stageNum==1)
        {
            SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && stageNum == 2)
        {
            SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && stageNum == 3)
        {
            SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && stageNum == 4)
        {
            SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && stageNum == 5)
        {
            SceneManager.LoadScene("Stage5", LoadSceneMode.Single);
        }
    }

}
