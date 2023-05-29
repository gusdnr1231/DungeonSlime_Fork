using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using FD.Dev;

public class PlayerDie : PlayerRoot
{
    private readonly int IsDieHash = Animator.StringToHash("IsDie");
    private readonly int DieHash = Animator.StringToHash("Die");
    [SerializeField] private UnityEvent restartEvent;
    [SerializeField] private Material paintwhiteMat;
    private Material defaultMat;
    private PlayerMove playerMove;

    public void PlayerDieEvent()
    {
        //못 움직여
        playerMove = GetComponent<PlayerMove>();
        playerMove.moveAble = false;

        //Sound
        AudioManager.Instance.PlayAudio("PlayerDie", audioSource);

        //잠시 하얀색으로
        defaultMat = spriteRenderer.material;
        spriteRenderer.material = paintwhiteMat;

        CameraManager.instance.ShackCamera(2f, 1f, 0.1f);

        FAED.InvokeDelay(() =>
        {
            spriteRenderer.material = defaultMat;
            PlayDieAnimation(); // 애니메이션에서 끝날 때 DieAndRestart실행될 예정
        }, 0.1f);
    }

    private void PlayDieAnimation()
    {
        SetDieAnimation(true);
    }

    public void DieAndRestart()
    {
        SetDieAnimation(false);
        restartEvent?.Invoke();
    }

    private void SetDieAnimation(bool enabled)
    {
        animator.SetBool("IsDie", enabled);
        if (enabled)
            animator.SetTrigger(DieHash);
        else
            animator.ResetTrigger(DieHash);
    }
}
