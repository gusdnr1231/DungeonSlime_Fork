using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ScenePanelManager : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private string sceneName;

    public void InScene()
    {
        image.DOFade(0, 1f);
    }

    public void OutScene()
    {
        image.DOFade(1, 1f).OnComplete(() => {
            SceneManager.LoadScene(sceneName);
        });
    }
}
