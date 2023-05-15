using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using DG.Tweening;

public class BossHP : MonoBehaviour
{
    public static BossHP Instance;

    [SerializeField] private GameObject bossClearObject;
    [SerializeField] CinemachineVirtualCamera _vCam;
    CinemachineBasicMultiChannelPerlin _vCamPerlin;

    private new PolygonCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private PlayerMove _playerMove;

    public int Boss_hp;

    void Awake()
    {
        Instance = this;

        collider = gameObject.GetComponent<PolygonCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _playerMove = FindObjectOfType<PlayerMove>();
        _vCamPerlin = _vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        Debug.Log(_vCamPerlin);
        bossClearObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void Die()
    {
        if (Boss_hp <= 0)
        {
            Boss_hp = 10;
            collider.enabled = false;
            bossClearObject.SetActive(true);

            transform.DOMoveY(transform.position.y + 3, 0.5f).SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                transform.DOMoveY(transform.position.y - 60, 3f).SetEase(Ease.InCubic)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
            });
        }
    }

    public void Hit()
    {
        StartCoroutine(ShakeCamcoroutine(0f, 0.4f, 25f));
        StartCoroutine(BossHit(0.1f));
        Boss_hp--;
    }

    IEnumerator BossHit(float _time)
    {
        int i;
        for (i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(_time);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(_time);
            spriteRenderer.color = Color.white;
        }
    }

    IEnumerator ShakeCamcoroutine(float waittime, float time, float shakeValue)
    {
        yield return new WaitForSeconds(waittime);
        _vCamPerlin.m_AmplitudeGain = shakeValue;
        float currentTime = 0f;
        while (currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            _vCamPerlin.m_AmplitudeGain = Mathf.Lerp(shakeValue, 0, currentTime / time);
            currentTime += Time.deltaTime;
        }
        _vCamPerlin.m_AmplitudeGain = 0;
    }
}