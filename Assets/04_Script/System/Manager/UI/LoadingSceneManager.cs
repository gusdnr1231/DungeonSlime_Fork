using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{

    private void Start()
    {

        StartCoroutine(LoadingSceneCo());

    }

    private IEnumerator LoadingSceneCo()
    {

        string value = PlayerPrefs.GetString("NextScene");
        PlayerPrefs.DeleteKey("NextScene");

        var oper = SceneManager.LoadSceneAsync(value);
        oper.allowSceneActivation = false;

        yield return new WaitUntil(() =>
        {

            return oper.progress >= 0.9f;

        });

        yield return new WaitForSeconds(0.5f);

        oper.allowSceneActivation = true;

    }

}
