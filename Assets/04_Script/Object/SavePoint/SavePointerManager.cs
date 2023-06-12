using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class SavePointerManager : MonoBehaviour
{
    public Vector2 savePos;
    private GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInput>().gameObject;
    }

    private void Start()
    {
        FAED.InvokeDelay(() => 
        {
            if (PlayerPrefs.GetInt("PosSave") == 1)
            {
                PlayerPrefs.SetInt("PosSave", 0);
                float x = PlayerPrefs.GetFloat("SavePosX");
                float y = PlayerPrefs.GetFloat("SavePosY");
                player.transform.position = new Vector2(x, y);
            }
        }, 0.005f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            SavePoint();
    }

    public void SavePoint()
    {
        if (savePos != Vector2.zero)
        {
            PlayerPrefs.SetInt("PosSave", 1);
            PlayerPrefs.SetFloat("SavePosX", savePos.x);
            PlayerPrefs.SetFloat("SavePosY", savePos.y);
        }
    }
}
