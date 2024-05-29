using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool union = false;
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x*0.4f, transform.localScale.y*0.4f, transform.localScale.z);

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerController.changchar)
        {
            spriteRenderer.sprite = newSprite;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
           // gameObject.GetComponent<Renderer>().material.color = Color.black;
            union = true;
            Destroy(other.gameObject);

            boxCol = other.GetComponent<BoxCollider2D>();

            boxCol.enabled = false;
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
