using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class UiManager : MonoBehaviour
{

    [SerializeField] private RectTransform movementUI;
    [SerializeField] private float lenght = 1920;

    private MapManager mapManager;
    private AudioSource audioSource;
    private bool isMove = false;

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

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

    public void SetNextScene(string value)
    {

        PlayerPrefs.SetString("NextScene", value);

    }

    public void SetUIKey(float value)
    {

        PlayerPrefs.SetFloat("UIKey", value);

    }

    public void MoveChapterUI(bool value)
    {

        bool com = value ? movementUI.transform.localPosition.x >= lenght
            : movementUI.transform.localPosition.x <= -lenght;
        if (isMove || com) return;

        Vector3 vel = value ? new Vector2(1920, 0) : new Vector2(-1920, 0); 

        isMove = true;

        movementUI.transform.DOLocalMove(movementUI.transform.localPosition + vel, 0.5f)
        .OnComplete(() =>
        {

            isMove = false;

        });

    }

    public void SetSelectStageScene()
    {
        int stage = mapManager.currentStageNum;
        Debug.Log(stage);
        if (stage == 0)//Æ©Åä¸®¾ó
        {
            PlayerPrefs.SetString("NextScene", "TutorialSelect");
        }
        if ((stage >= 1 && stage <= 5) || stage == -1)//1Ã©ÅÍ
        {
            PlayerPrefs.SetString("NextScene", "SelectStage1");
        }
        else if ((stage >= 6 && stage <= 10) || stage == -2)//2Ã©ÅÍ
        {
            PlayerPrefs.SetString("NextScene", "SelectStage2");
        }
    }

    public void SoundEffect()
    {

        audioSource.Play();

    }

}
