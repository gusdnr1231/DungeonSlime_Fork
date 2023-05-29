using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    public int currentStageNum { get; private set; } = 1;

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

            Debug.Log(123);
            PlayerPrefs.SetString("NextScene", "SelectStage1");
            SceneManager.LoadScene("Loading");
            return;

        }

        var map = Instantiate(Resources.Load<GameObject>($"Map/{currentStageNum}")).GetComponent<Map>();
        var player = GameObject.Find("Player");
        CameraManager.instance.SetCof(map.cameraLockZone);
        player.transform.position = map.StartPos.position;
        CutSceneManager.instance.CutSceneActive();
    }

    public void RestartMap()
    {

        Destroy(FindObjectOfType<Map>().gameObject);

        var map = Instantiate(Resources.Load<GameObject>($"Map/{currentStageNum}")).GetComponent<Map>();

        var player = GameObject.Find("Player");
        CameraManager.instance.SetCof(map.cameraLockZone);
        player.transform.position = map.StartPos.position;

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