using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class InvisibleWall : MonoBehaviour
{

    [SerializeField] private float dessolvePower;

    private TilemapRenderer tilemapRenderer;
    private string[] tagStr;
    private bool isFade;

    private void Awake()
    {
        
        tilemapRenderer = GetComponent<TilemapRenderer>();

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

            tilemapRenderer.material.color = new Color(oldC.r, oldC.g, oldC.b, 
                oldC.a - dessolvePower * Time.deltaTime);

        }

    }

}
