using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    public GameObject BulletObj;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        BulletObj.transform.Translate(fMoveSpeed * Time.deltaTime, 0, 0);


    }
}
