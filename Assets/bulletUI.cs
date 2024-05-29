using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bulletUI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite bulletSprite1;
    public Sprite bulletSprite2;
    public Sprite bulletSprite3;
    public Sprite bulletSprite4;
    public Sprite bulletSprite5;
    public Sprite bulletSprite0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.bulletcount == 1)
        {
            spriteRenderer.sprite = bulletSprite1;
        }
        if (PlayerController.bulletcount == 2)
        {
            spriteRenderer.sprite = bulletSprite2;
        }

        if (PlayerController.bulletcount == 3)
        {
            spriteRenderer.sprite = bulletSprite3;
        }
        if (PlayerController.bulletcount == 4)
        {
            spriteRenderer.sprite = bulletSprite4;
        }
        if (PlayerController.bulletcount == 5)
        {
            spriteRenderer.sprite = bulletSprite5;
        }
        if (PlayerController.bulletcount == 0)
        {
            spriteRenderer.sprite = bulletSprite0;
        }

    }
}
