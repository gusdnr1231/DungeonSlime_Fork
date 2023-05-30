using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FadeUI : MonoBehaviour
{

    [SerializeField] private float fadeTime;
    [SerializeField] private UnityEvent ftsEvt, inEvt, outEvt;
    [SerializeField] private bool startFadeOut;
    private Image image;

    private void Awake()
    {
        
        image = GetComponent<Image>();

    }

    private void Start()
    {

        if (startFadeOut)
        {

            image.DOFade(0, fadeTime);

        }

    }

    public void FadeIn()
    {

        image.DOFade(1, fadeTime).OnComplete(() =>
        {   
            if (PlayerPrefs.GetInt("FirstStart") == 1)
                inEvt?.Invoke();
            else
            {
                PlayerPrefs.SetInt("FirstStart", 1);
                ftsEvt?.Invoke();
            }
        });

    }

    public void FadeOut()
    {

        image.DOFade(0, fadeTime).OnComplete(() =>
        {

            inEvt?.Invoke();

        });


    }

    public void FadeIn(string name)
    {

        image.DOFade(1, fadeTime).OnComplete(() =>
        {

            inEvt?.Invoke();
            SceneManager.LoadScene(name);

        });

    }

}
