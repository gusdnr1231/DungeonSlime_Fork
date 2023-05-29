using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingChapterPos : MonoBehaviour
{

    private void Start()
    {

        transform.localPosition = new Vector2(PlayerPrefs.GetFloat("UIKey"), 0);

    }

}
