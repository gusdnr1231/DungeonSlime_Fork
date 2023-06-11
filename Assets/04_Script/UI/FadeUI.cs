using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using FD.Dev;

public class FadeUI : MonoBehaviour
{

    [SerializeField] private float fadeTime;
    [SerializeField] private UnityEvent ftsEvt, inEvt, outEvt;
    [SerializeField] private bool startFadeOut;
    private RectTransform rectTrs;
    [SerializeField] RectTransform rectTrs2;
    [SerializeField] RectTransform rectTrs3;

    bool isFading;

    private void Awake()
    {

        rectTrs = GetComponent<RectTransform>();
        RectSetting(rectTrs);
        RectSetting(rectTrs2);
        RectSetting(rectTrs3);

    }

    void RectSetting(RectTransform re)
    {
        re.anchoredPosition = new Vector3(0, 1300, 0);
        re.sizeDelta = new Vector2(1920, 1400);
    }

    private void Start()
    {

        if (startFadeOut)
        {

            rectTrs.anchoredPosition = new Vector3(0, 0, 0);
            rectTrs2.anchoredPosition = new Vector3(0, 0, 0);
            rectTrs3.anchoredPosition = new Vector3(0, 0, 0);
            DOTween.KillAll();
            rectTrs.DOMoveY(-700, fadeTime).SetEase(Ease.InCirc);
            FAED.InvokeDelay(() => { rectTrs2.DOMoveY(-700, fadeTime).SetEase(Ease.InCirc); }, 0.2f);
            FAED.InvokeDelay(() => { rectTrs3.DOMoveY(-700, fadeTime).SetEase(Ease.InCirc); }, 0.4f);

        }

    }

    public void FadeIn()
    {
        if (!isFading)
        {
            isFading = true;
            DOTween.KillAll();
            rectTrs.anchoredPosition = new Vector3(0, 1300, 0);
            rectTrs2.anchoredPosition = new Vector3(0, 1300, 0);
            rectTrs3.anchoredPosition = new Vector3(0, 1300, 0);
            FAED.InvokeDelay(() =>
            {
                rectTrs3.DOMoveY(540, fadeTime).SetEase(Ease.OutCirc)
                .OnComplete(() =>
                {

                    if (PlayerPrefs.GetInt("FirstStart") == 1)
                        inEvt?.Invoke();
                    else
                    {
                        PlayerPrefs.SetInt("FirstStart", 1);
                        ftsEvt?.Invoke();
                    }
                });
            }, 0.4f);
            rectTrs.DOMoveY(540, fadeTime).SetEase(Ease.OutCirc);
            FAED.InvokeDelay(() => { rectTrs2.DOMoveY(540, fadeTime).SetEase(Ease.OutCirc); }, 0.2f);
        }
    }

    public void FadeOut()
    {

        DOTween.KillAll();
        FAED.InvokeDelay(() => { rectTrs3.DOMoveY(-700, fadeTime).SetEase(Ease.InCirc); }, 0.4f);
        FAED.InvokeDelay(() => { rectTrs2.DOMoveY(-700, fadeTime).SetEase(Ease.InCirc); }, 0.2f);
        rectTrs.DOMoveY(-700, fadeTime).SetEase(Ease.InCirc).OnComplete(() =>  
        {

            inEvt?.Invoke();

        });


    }

    public void FadeIn(string name)
    {
        if (!isFading)
        {
            isFading = true;
            DOTween.KillAll();
            rectTrs.anchoredPosition = new Vector3(0, 1300, 0);
            rectTrs2.anchoredPosition = new Vector3(0, 1300, 0);
            rectTrs3.anchoredPosition = new Vector3(0, 1300, 0);
            FAED.InvokeDelay(() =>
            {
                rectTrs3.DOMoveY(540, fadeTime).SetEase(Ease.OutCirc)
                .OnComplete(() =>
                {

                    inEvt?.Invoke();
                    SceneManager.LoadScene(name);

                });
            }, 0.4f);
            rectTrs.DOMoveY(540, fadeTime).SetEase(Ease.OutCirc);
            FAED.InvokeDelay(() => { rectTrs2.DOMoveY(540, fadeTime).SetEase(Ease.OutCirc); }, 0.2f);
        }
    }

}
