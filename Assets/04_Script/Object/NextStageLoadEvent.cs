using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageLoadEvent : MonoBehaviour
{
    
    public void Load()
    {

        Managers.Map.SetCurrentStageNumber(Managers.Map.currentStageNum + 1);
        PlayerPrefs.SetString("NextScene", "StartLoadingMap");
        SceneManager.LoadScene("Loading");

    }

}
