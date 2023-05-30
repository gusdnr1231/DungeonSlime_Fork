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
    private bool isClearAble;
    private Door door;

    private IEnumerator Start()
    {
        yield return null;
        image = GameObject.Find("JumpIcon").GetComponent<Image>();
        door = FindObjectOfType<Door>();

    }

    public void SetOrigin()
    {

        image.sprite = origin;
        isClearAble = false;

    }

    public void SetNonJump(bool value)
    {

        if(!value) image.sprite = noneJump;

    }

    public void SetClear()
    {

        image.sprite = clear;
        isClearAble = true;

    }

    public void ClearEvent()
    {

        if (isClearAble)
        {

            FindObjectOfType<GemObject>()?.TrySave();
            door.clearEvent?.Invoke();

        }

    }


}
