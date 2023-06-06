using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FD.Dev;
using UnityEngine.Windows;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineVirtualCamera vcam;

    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private SpeakManager speakManager;
    private Animator opendoorAnim;
    private Vector3 startPos;
    private float camerSize;

    private void Awake()
    {
        instance = this;
        playerMove = player.GetComponent<PlayerMove>();
        playerJump = player.GetComponent<PlayerJump>();
    }

    public void CutSceneActive()
    {
        playerMove.moveAble = false;
        playerJump.RemoveEvent();

        speakManager = FindObjectOfType<SpeakManager>();

        startPos = FindObjectOfType<CutSize>().gameObject.transform.position;
        startPos.z = -10;
        camerSize = FindObjectOfType<CutSize>().size;

        opendoorAnim = GameObject.FindWithTag("StartDoor").GetComponent<Animator>();
        opendoorAnim.enabled = false;

        vcam.transform.position = startPos;
        vcam.m_Lens.OrthographicSize = camerSize;
        vcam.Follow = null;

        Vector3 playerPos = player.transform.position;
        playerPos.z = -10;

        FAED.InvokeDelay(() =>
        {
            vcam.transform.DOMove(playerPos, 1).OnComplete(() => {
                vcam.Follow = player.transform;
                DOTween.To(() => vcam.m_Lens.OrthographicSize, x => vcam.m_Lens.OrthographicSize = x, 5, 1)
                .OnComplete(() => {
                    opendoorAnim.enabled = true;
                    speakManager.StartScript();
                    speakManager.canToking = true;
                });
            });
        }, 2f);
    }
}
