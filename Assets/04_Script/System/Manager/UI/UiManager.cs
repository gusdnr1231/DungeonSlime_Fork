using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    [SerializeField] private RectTransform movementUI;
    private bool isMove = false;

    public void ChangeScene(string value)
    {

        SceneManager.LoadScene(value);

    }

    public void ExitGame()
    {

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#endif
        Application.Quit();

    }

    public void MoveChapterUI(bool value)
    {

        bool com = value ? movementUI.transform.localPosition.x >= 7680
            : movementUI.transform.localPosition.x <= -7680;
        if (isMove || com) return;

        Vector3 vel = value ? new Vector2(1920, 0) : new Vector2(-1920, 0); 

        isMove = true;

        movementUI.transform.DOLocalMove(movementUI.transform.localPosition + vel, 0.5f)
        .OnComplete(() =>
        {

            isMove = false;

        });

    }

}
