using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapEventManager : MonoBehaviour
{
    
    public void LoadMap(int count)
    {
        PlayerPrefs.SetInt("StageStart", 1);
        Managers.Map.SetCurrentStageNumber(count);
        PlayerPrefs.SetString("NextScene", "StartLoadingMap");
        SceneManager.LoadScene("Loading");

    }

    public void RestartMap()
    {

        Managers.Map.SetCurrentStageNumber(Managers.Map.currentStageNum);
        Managers.Map.LoadMap();

    }


}
