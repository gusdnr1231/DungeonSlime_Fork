using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{

    [SerializeField] private TMP_Text text;
    [SerializeField] private LoadingTextSO textSO;

    private void Start()
    {

        text.text = FAED.Random(textSO.loadingText);
        StartCoroutine(LoadingSceneCo());

    }

    private IEnumerator LoadingSceneCo()
    {

        string value = PlayerPrefs.GetString("NextScene");
        PlayerPrefs.DeleteKey("NextScene");

        if(value == "StartLoadingMap")
        {

            var oper = SceneManager.LoadSceneAsync("TestMap");
            oper.allowSceneActivation = false;

            yield return new WaitUntil(() =>
            {

                return oper.progress >= 0.9f;

            });

            yield return new WaitForSeconds(1f);

            oper.allowSceneActivation = true;
            FAED.InvokeDelay(() => Managers.Map.CreateStage(), 0.01f);

        }
        else
        {

            var oper = SceneManager.LoadSceneAsync(value);
            oper.allowSceneActivation = false;

            yield return new WaitUntil(() =>
            {

                return oper.progress >= 0.9f;

            });

            yield return new WaitForSeconds(1f);

            oper.allowSceneActivation = true;

        }



    }

}
