using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //オブジェクト・コンポーネント参照
    private Rigidbody2D rigidbody2D;//Rigidbody2Dコンポーネント参照
    private SpriteRenderer spriteRenderer;

    //移動関連変数
    [HideInInspector]public float xSpeed;
    [HideInInspector] public static bool rightFacing;//右を向いているか　向いていたらtrue
    [HideInInspector] private bool isJump;

    //弾
    public GameObject BulletObj;
    // Vector3 bulletPoint;//弾の位置

    public float fMoveSpeed = 7.0f;
    float jumpPower = 10.0f;

    //public GameObject bulletPointObj;

    bool shot = false;
    Vector3 bulletpoint;
    int bulletcount = 5;

    public static Vector2 velocity;


    public GameObject EnemyObj;
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント参照取得
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //初期化変数
        rightFacing = true;
        isJump = false;

        bulletpoint = transform.position;
        //弾の発射位置
        //bulletPoint = transform.Find("BulletPoint").localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //左右移動
        MoveUpdate();
        //ジャンプ
        JumpUpdate();
        //弾
        /*if(Input.GetKeyDown(KeyCode.Space)) {
            //弾の生成
            Instantiate(
                BulletObj,
                transform.position+bulletPoint,
                Quaternion.identity
                );
        }*/
        if (Input.GetKeyDown(KeyCode.Space)&&0<bulletcount)
        {
            Instantiate(BulletObj, transform.position, Quaternion.identity);
            bulletcount--;
        }
       if (Enemy.union)
       {
            jumpPower = 20.0f;
            Destroy(EnemyObj.gameObject);
                
       }



    }
    
            
       
    


    private void MoveUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xSpeed = 6.0f;

            rightFacing = true;
            //spriteを通常の向きで表示
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            xSpeed = -6.0f;

            rightFacing = false;
            //spriteを左右反転の向きで表示
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    /// <summary>
    /// FixedUpdateはUnityの標準機能で何度も自動で呼び出されるメソッド 
    /// </summary>
    private void FixedUpdate()
    {
        //移動速度ベクトルを現在地から取得
        velocity = rigidbody2D.velocity;
        velocity.x = xSpeed;

        rigidbody2D.velocity = velocity;
    }
}
