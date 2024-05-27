using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]  
public class FollowCamera : MonoBehaviour
{
    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    //�J����Z���@player����}�C�i�X��
    private float cameraZPlus;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
        cameraZPlus = -30;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        //�������Ǐ]
        transform.position = new Vector3(playerTransform.position.x,transform.position.y,playerTransform.position.z + cameraZPlus);
    }
}
