using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{

    private void Start()
    {

        PlayerPrefs.SetInt("UnlockChapter", 1);
        PlayerPrefs.SetFloat("UIKey", 1920);

    }

}
