using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private GameObject bullet;
    public float fMoveSpeed = 7.0f;
    public GameObject BulletObj;


    // Start is called before the first frame update
    void Start()
    {
        //bullet = Resources.Load("Bullet") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
          if (Time.frameCount % 60 == 0)
          {
              //�e�̃C���X�^���X�𐶐�
              Instantiate(
              bullet,//��������I�u�W�F�N�g�̃v���n�u
              this.transform.position,//�����ʒu
              Quaternion.identity);//������]���
          }
        }
         this.transform.position += new Vector3(0.02f, 0, 0);*/


        BulletObj.transform.Translate(fMoveSpeed * Time.deltaTime, 0, 0);


    }
}