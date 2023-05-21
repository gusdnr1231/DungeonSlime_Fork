using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class InvisibleWall : MonoBehaviour
{

    [SerializeField] private float dessolvePower;
    [SerializeField] private string[] tagStr;

    private SpriteRenderer tilemapRenderer;
    private bool isFade;

    private void Awake()
    {
        
        tilemapRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach(var tag in tagStr)
        {

            if (collision.CompareTag(tag))
            {

                isFade = true;

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        foreach (var tag in tagStr)
        {

            if (collision.CompareTag(tag))
            {

                isFade = false;

            }

        }

    }

    private void Update()
    {

        if (isFade)
        {

            var oldC = tilemapRenderer.material.color;

            oldC = new Color(oldC.r, oldC.g, oldC.b,
                oldC.a - dessolvePower * Time.deltaTime);

            oldC = new Color(oldC.r, oldC.g, oldC.b,
                Mathf.Clamp(oldC.a, 0.3f, 1));

            tilemapRenderer.material.color = oldC;


        }
        else
        {

            var oldC = tilemapRenderer.material.color;

            oldC = new Color(oldC.r, oldC.g, oldC.b,
                oldC.a + dessolvePower * Time.deltaTime);

            tilemapRenderer.material.color = oldC;


        }

    }

}
