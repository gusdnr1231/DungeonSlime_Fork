using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapEventManager : MonoBehaviour
{
    
    public void LoadMap(int count)
    {

        Managers.Map.SetCurrentStageNumber(count);
        PlayerPrefs.SetString("NextScene", "StartLoadingMap");
        SceneManager.LoadScene("Loading");

    }

    public void RestartMap()
    {



    }

}
