using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageselect : MonoBehaviour
{
    int count = 1;

    private SpriteRenderer spriteRenderer;

    public Sprite stageslectSprite1;
    public Sprite stageslectSprite2;
    public Sprite stageslectSprite3;
    public Sprite stageslectSprite4;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))&& count <= 3)
        {
            count++;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))&&count>=2)
        {
            count--;
        }
        if (count == 1)
        {
            spriteRenderer.sprite = stageslectSprite1;
        }
        if (count == 2)
        {
            spriteRenderer.sprite = stageslectSprite2;
        }

        if (count == 3)
        {
            spriteRenderer.sprite = stageslectSprite3;
        }
        if (count == 4)
        {
            spriteRenderer.sprite = stageslectSprite4;
        }
    }
}
