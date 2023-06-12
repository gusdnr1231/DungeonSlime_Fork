using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    [SerializeField] private bool isTesting = false;
    [field:SerializeField] public int currentStageNum { get; private set; } = 1;

    SkulBossIdle skulBossIdle;

    private void Awake()
    {
        
        if(isTesting) 
        {

            CreateStage();

        }

    }

    public void SetCurrentStageNumber(int number)
    {

        currentStageNum = number;

    }

    public void LoadMap()
    {

        StartCoroutine(MapLoadingCo());
        
    }

    public void CreateStage()
    {

        if(Resources.Load<GameObject>($"Map/{currentStageNum}") == null)
        {

            PlayerPrefs.SetString("NextScene", "SelectStage1");
            SceneManager.LoadScene("Loading");
            return;

        }

        var map = Instantiate(Resources.Load<GameObject>($"Map/{currentStageNum}")).GetComponent<Map>();
        var player = GameObject.Find("Player");
        CameraManager.instance.SetCof(map.cameraLockZone);
        player.transform.position = map.StartPos.position;
        if (PlayerPrefs.GetInt("StageStart") == 1)
        {
            PlayerPrefs.SetInt("StageStart", 0);
            CutSceneManager.instance.CutSceneActive();
        }
        else
        {
            skulBossIdle = FindObjectOfType<SkulBossIdle>();
            skulBossIdle.start = true;
        }
    }

    public void RestartMap()
    {

        SceneManager.LoadScene("TestMap");
        FAED.InvokeDelay(() => Managers.Map.CreateStage(), 0.001f);

    }

    IEnumerator MapLoadingCo()
    {

        var maploading = SceneManager.LoadSceneAsync("TestMap");

        yield return new WaitUntil(() =>
        {

            return maploading.isDone;

        });

        yield return null;

        CreateStage();

    }

}