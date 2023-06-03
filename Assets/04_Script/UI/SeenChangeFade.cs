using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeenChangeFade : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rectTransform.DOMoveY(540, 1).SetEase(Ease.InCirc).OnComplete(() =>
            {
                rectTransform.DOMoveY(0, 1).SetEase(Ease.OutCirc);
            });
            rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, 1080), 1).SetEase(Ease.InCirc).OnComplete(() =>
            {
                rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, 0), 1).SetEase(Ease.OutCirc);
            });
        }
    }

    void StartFade()
    {
        rectTransform.DOMoveY(540, 1).SetEase(Ease.InCirc);
        rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, 1080), 1).SetEase(Ease.InCirc);
    }

    void EndFade()
    {
        rectTransform.DOMoveY(0, 1).SetEase(Ease.OutCirc);
        rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, 0), 1).SetEase(Ease.OutCirc);
    }
}
