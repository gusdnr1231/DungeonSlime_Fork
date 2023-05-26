using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FD.Dev;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineVirtualCamera vcam;

    private PlayerInput input;
    private PlayerJump playerJump;
    private SpeakManager speakManager;
    private Vector3 startPos;
    private float camerSize;

    private void Awake()
    {
        instance = this;
    }

    public void CutSceneActive()
    {
        speakManager = FindObjectOfType<SpeakManager>();

        input = player.GetComponent<PlayerInput>();
        playerJump = player.GetComponent<PlayerJump>();
        input.enabled = false;
        playerJump.enabled = false;

        startPos = FindObjectOfType<CutSize>().gameObject.transform.position;
        startPos.z = -10;
        camerSize = FindObjectOfType<CutSize>().size;

        vcam.transform.position = startPos;
        vcam.m_Lens.OrthographicSize = camerSize;
        vcam.Follow = null;

        Vector3 playerPos = player.transform.position;
        playerPos.z = -10;

        FAED.InvokeDelay(() =>
        {
            vcam.transform.DOMove(playerPos, 1);
            DOTween.To(() => vcam.m_Lens.OrthographicSize, x => vcam.m_Lens.OrthographicSize = x, 5, 1)
            .OnComplete(() => { 
                vcam.Follow = player.transform;
                speakManager.StartScritp();
                speakManager.canToking = true;
            });
        }, 2f);
    }
}
