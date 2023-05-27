using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterObject : MonoBehaviour
{

    [SerializeField] private Image lockImage;
    [SerializeField] private string mapKey;

    private ImageClickEvent evt;

    private void Awake()
    {
        
        evt = GetComponent<ImageClickEvent>();

    }

    private void Start()
    {
        
        if(Managers.Chapter.ClearChack(mapKey)) 
        {

            lockImage.gameObject.SetActive(true);
            evt.enabled = false;
        
        }

    }

}
