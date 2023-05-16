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

        var map = Instantiate(Resources.Load<GameObject>($"Map/{currentStageNum}")).GetComponent<Map>();

        var player = GameObject.Find("Player");
        player.transform.position = map.StartPos.position;

    }

    IEnumerator MapLoadingCo()
    {

        var maploading = SceneManager.LoadSceneAsync("TestMap");

        yield return new WaitUntil(() =>
        {

            return maploading.isDone;

        });

        
        CreateStage();

    }

}