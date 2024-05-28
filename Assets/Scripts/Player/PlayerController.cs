using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //�I�u�W�F�N�g�E�R���|�[�l���g�Q��
    private Rigidbody2D rigidbody2D;//Rigidbody2D�R���|�[�l���g�Q��
    private SpriteRenderer spriteRenderer;
    //�ړ��֘A�ϐ�
    [HideInInspector] public float xSpeed;
    [HideInInspector] public bool rightFacing;//�E�������Ă��邩�@�����Ă�����true
    [HideInInspector] private bool isJump;

    //�e
    public GameObject BulletObj;
    // Vector3 bulletPoint;//�e�̈ʒu
    // Vector3 bulletPoint;//�e�̈ʒu

    public float fMoveSpeed = 7.0f;

    //public GameObject bulletPointObj;

    bool shot = false;
    Vector3 bulletpoint;



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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletObj, transform.position, Quaternion.identity);
        }



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
        if (isJump == false && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            isJump = true;
            float jumpPower = 10.0f;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    /// <summary>
    /// FixedUpdate��Unity�̕W���@�\�ŉ��x�������ŌĂяo����郁�\�b�h 
    /// </summary>
    private void FixedUpdate()
    {
        //�ړ����x�x�N�g�������ݒn����擾
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = xSpeed;
        rigidbody2D.velocity = velocity;
    }
}