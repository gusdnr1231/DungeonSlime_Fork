using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpeakStage
{
    public List<string> _peaks;
}

public class SpeakManager : MonoBehaviour
{
    [SerializeField] private List<SpeakStage> speak;
    [SerializeField] GameObject speakWindow;
    Camera mainCam;
    Canvas canvas;
    PlayerInput playerInput;
    PlayerJump playerJump;
    PlayerMove playerMove;
    GameObject player;
    MapManager mapManager;
    SkulBossIdle skulBossIdle;
    TextMeshProUGUI text;

    private RectTransform window;
    public bool canToking;
    int nowStage;
    int speakCnt;

    public void StartScript()
    {
        mainCam = Camera.main;
        canvas = GameObject.FindWithTag("GameCanvers").GetComponent<Canvas>();
        window = Instantiate(speakWindow, canvas.transform.GetChild(0)).GetComponent<RectTransform>();
        text = window.GetChild(0).GetComponent<TextMeshProUGUI>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerJump = FindObjectOfType<PlayerJump>();
        playerMove = FindObjectOfType<PlayerMove>();
        player = playerMove.gameObject;
        mapManager = FindObjectOfType<MapManager>();
        nowStage = mapManager.currentStageNum;

        if (nowStage == -1)
        {
            skulBossIdle = FindObjectOfType<SkulBossIdle>();
        }
    }

    private void Update()
    {
        if (canToking)
        {
            WindowUp();

            if (speakCnt == 0)
                Toking();
        }
    }

    public void Skeep()
    {

    }

    void WindowUp()
    {
        Vector3 windowVec = new Vector3(player.transform.position.x, player.transform.position.y + 2, 0);
        Vector3 windowPos = mainCam.WorldToScreenPoint(windowVec);

        if (windowPos.x < 230)
            windowPos.x = 230;
        else if (windowPos.x > 1700)
            windowPos.x = 1700;

        if (windowPos.y < 240)
            windowPos.y = 240;
        else if (windowPos.y > 960)
            windowPos.y = 960;

        window.position = windowPos;
    }

    public void TokingEnd()
    {
        if (canToking && speak[nowStage + 2]._peaks.Count <= speakCnt)
        {
            canToking = false;
            canToking = false;
            playerMove.moveAble = true;
            playerJump.AddEvent();
            window.gameObject.SetActive(false);
            if (nowStage == -1)
                skulBossIdle.start = true;
        }
    }

    public void Toking()
    {
        if (canToking)
        {
            text.text = "";
            StopAllCoroutines();
            StartCoroutine(Speak(speak[nowStage + 2]._peaks[speakCnt]));
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
