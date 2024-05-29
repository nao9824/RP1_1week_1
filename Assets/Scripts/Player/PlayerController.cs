using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //�I�u�W�F�N�g�E�R���|�[�l���g�Q��
    private Rigidbody2D rigidbody2D;//Rigidbody2D�R���|�[�l���g�Q��
    private SpriteRenderer spriteRenderer;

    //�ړ��֘A�ϐ�
    [HideInInspector]public float xSpeed;
    [HideInInspector] public static bool rightFacing;//�E�������Ă��邩�@�����Ă�����true
    [HideInInspector] private bool isJump;

    //�e
    public GameObject BulletObj;
    // Vector3 bulletPoint;//�e�̈ʒu

    public float fMoveSpeed = 7.0f;
    float jumpPower = 10.0f;

    //public GameObject bulletPointObj;

    bool shot = false;
    Vector3 bulletpoint;

    
    public static int bulletcount = 3;

    public static bool changchar = false;

    public static Vector2 velocity;

    Vector3 tentative;

    private Image image;

    public Sprite newSprite;

    public Sprite mainSprite;

    public GameObject EnemyObj;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�Q�Ǝ擾
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //�������ϐ�
        rightFacing = true;
        isJump = false;

        bulletpoint = transform.position;

        image = GetComponent<Image>();
        //�e�̔��ˈʒu
        //bulletPoint = transform.Find("BulletPoint").localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //���E�ړ�
        MoveUpdate();
        //�W�����v
        JumpUpdate();
        //�e
        /*if(Input.GetKeyDown(KeyCode.Space)) {
            //�e�̐���
            Instantiate(
                BulletObj,
                transform.position+bulletPoint,
                Quaternion.identity
                );
        }*/
        if (Input.GetKeyDown(KeyCode.Space)&&0<bulletcount&& !changchar)
        {
            Instantiate(BulletObj, transform.position, Quaternion.identity);
            bulletcount--;
        }
       if (Enemy.union)
       {
            
            
            tentative = transform.position;

            transform.position = EnemyObj.transform.position;


            transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y, transform.localScale.z);

            changchar = true;

            Destroy(EnemyObj.gameObject);
            //Instantiate(EnemyObj,new Vector3(tentative.x, tentative.y, tentative.z), Quaternion.identity);

            //�����ŉ摜����ւ�
            spriteRenderer.sprite = newSprite;

            Enemy.union = false;



        }
        if (Input.GetKeyDown(KeyCode.E) && changchar)
        {
            spriteRenderer.sprite = mainSprite;
            changchar = false;
        }
      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Toge") && !changchar)
        {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
            bulletcount = 3;
        }
    }


        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (EnemyObj.transform.position.y < transform.position.y-0.4f)
            {
                Destroy(EnemyObj);
                bulletcount++;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Toge")&&!changchar)
        {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name, LoadSceneMode.Single);
            bulletcount = 3;
        }
        else { isJump = false; }
        if (collision.gameObject.CompareTag("Clear"))
        {
            Debug.Log("Clear");
            SceneManager.LoadScene("Clear", LoadSceneMode.Single);
        }
        //if (Enemy.union)
        //{
        //    tentative = transform.position;
        //    Destroy(EnemyObj);
        //    transform.position = EnemyObj.transform.position;
        //    changchar = true;

        //}
    }



    private void MoveUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xSpeed = 6.0f;

            rightFacing = true;
            //sprite��ʏ�̌����ŕ\��
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            xSpeed = -6.0f;

            rightFacing = false;
            //sprite�����E���]�̌����ŕ\��
            spriteRenderer.flipX = true;
        }
        else
        {
            xSpeed = 0.0f;
        }

        

    }

    private void JumpUpdate()
    {
        if(isJump == false && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
            isJump = true;
           
            rigidbody2D.velocity=new Vector2(rigidbody2D.velocity.x,jumpPower);
        }
    }

    


    /// <summary>
    /// FixedUpdate��Unity�̕W���@�\�ŉ��x�������ŌĂяo����郁�\�b�h 
    /// </summary>
    private void FixedUpdate()
    {
        //�ړ����x�x�N�g�������ݒn����擾
        velocity = rigidbody2D.velocity;
        velocity.x = xSpeed;

        rigidbody2D.velocity = velocity;
    }
}
