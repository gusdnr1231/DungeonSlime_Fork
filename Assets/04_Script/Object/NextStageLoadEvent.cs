using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FD.Dev;
using static UnityEngine.Rendering.DebugUI;

public class NextStageLoadEvent : MonoBehaviour
{

    private void LoadEmpact()
    {
        PlayerPrefs.SetInt("StageStart", 1);
        SpriteRenderer player = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        player.DOFade(0, 0.5f).OnComplete(() => {
            gameObject.GetComponent<Animator>().enabled = true;
        });
    }

    public void Load()
    {
        LoadEmpact();

        FAED.InvokeDelay(() => 
        {
            Managers.Map.SetCurrentStageNumber(Managers.Map.currentStageNum + 1);
            PlayerPrefs.SetString("NextScene", "StartLoadingMap");
            SceneManager.LoadScene("Loading");
        }, 1f);

    }

    public void BossLoad(int num)
    {
        LoadEmpact();

        FAED.InvokeDelay(() =>
        {
            Managers.Map.SetCurrentStageNumber(num);
            PlayerPrefs.SetString("NextScene", "StartLoadingMap");
            SceneManager.LoadScene("Loading");
        }, 1f);

    }

    public void ClearChapter()
    {
        LoadEmpact();

        FAED.InvokeDelay(() =>
        {
            PlayerPrefs.SetString("NextScene", "SelectStage1");
            SceneManager.LoadScene("Loading");
        }, 1f);
    }

}
