using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakManager : MonoBehaviour
{
    [SerializeField] GameObject speakWindow;
    [SerializeField] Text text;
    [SerializeField] List<string[]> speak;
    PlayerInput playerInput;
    MapManager mapManager;
    public bool canToking;
    int nowStage;
    int speakCnt;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        mapManager = FindObjectOfType<MapManager>();
        nowStage = mapManager.currentStageNum;

        speakWindow.SetActive(false);
    }

    private void Update()
    {
        if (speak[nowStage - 1].Length >= speakCnt)
        {
            canToking = false;
            playerInput.enabled = true;
            //게임 시작
        }
    }

    public void Toking()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canToking)
        {
            StartCoroutine(Speak(speak[nowStage - 1][speakCnt]));
            speakCnt++;
        }
    }

    IEnumerator Speak(string s)
    {
        text.text = "";
        for (int i = 0; i < s.Length; i++)
        {
            text.text += s[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
