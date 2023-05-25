using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpUISetting : MonoBehaviour
{

    [SerializeField] private Sprite origin;
    [SerializeField] private Sprite noneJump;
    [SerializeField] private Sprite clear;

    private Image image;

    private void Awake()
    {
        
        image = GetComponent<Image>();

    }

    public void SetOrigin()
    {

        image.sprite = origin;

    }

    public void SetNonJump(bool value)
    {

        if(!value) image.sprite = noneJump;

    }

    public void SetClear()
    {

        image.sprite = clear;

    }

}
