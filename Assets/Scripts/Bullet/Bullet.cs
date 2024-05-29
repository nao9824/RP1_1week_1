using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    public GameObject BulletObj;
    bool rightFacing = PlayerController.rightFacing;
    public GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

        if (rightFacing)
        {

            BulletObj.transform.Translate(fMoveSpeed * Time.deltaTime, 0, 0);
            if (PlayerObj.transform.position.x + 30.0f < BulletObj.transform.position.x)
            {
                Destroy(gameObject);
            }

        }
        

        if (!rightFacing)
        {
            BulletObj.transform.Translate(-fMoveSpeed * Time.deltaTime, 0, 0);
            if (PlayerController.velocity.x - 30 > BulletObj.transform.position.x)
            {
                Destroy(gameObject);
            }
        }

        

    }
}
