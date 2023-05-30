using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterObject : MonoBehaviour
{

    [SerializeField] private Image lockImage;
    [SerializeField] private string mapKey;
    [SerializeField] private Color noClearColor = Color.white;

    private Image rootImage;
    private ImageClickEvent evt;

    private void Awake()
    {
        
        rootImage = GetComponent<Image>();
        evt = GetComponent<ImageClickEvent>();

    }

    private void Start()
    {
        
        if(!Managers.Chapter.ClearChack(mapKey)) 
        {

            rootImage.color = noClearColor;
            lockImage.gameObject.SetActive(true);
            evt.enabled = false;
        
        }
        else
        {

            rootImage.color = Color.white;

        }

    }

}
