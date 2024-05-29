using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool union = false;
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.changchar)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            union = true;
            Destroy(other.gameObject);
            

        }

        if (union)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        
    }

    
}
