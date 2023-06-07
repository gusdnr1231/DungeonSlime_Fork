using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLaser : MonoBehaviour
{
    [SerializeField] private Vector2 dir;
    private readonly float dist = 100;
    private readonly float laserTime = 0.3f;
    private readonly float maxWidth = 0.7f;

    private bool isShot = false;

    public void Shot(LineRenderer lineRenderer)
    {
        if (isShot == true) return;
        isShot = true;
        StartCoroutine(ShotLaserCo(lineRenderer));
    }

    private void UseLineRenderer(LineRenderer lineRenderer, bool use)
    {
        lineRenderer.enabled = use;
    }
    private void DrawLine(LineRenderer lineRenderer, Vector2 endPos, float width)
    {
        Vector2 startPos = transform.parent.position;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    IEnumerator ShotLaserCo(LineRenderer lineRenderer)
    {
        float currentTime = 0;
        
        UseLineRenderer(lineRenderer, true);
        while(currentTime <= laserTime)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dist);
            Vector2 endPos = (hit.collider) ? hit.point : transform.position + (Vector3)dir.normalized * dist;

            float width = (1 - easeOutElastic(Mathf.Lerp(0, 1, currentTime / laserTime))) * maxWidth;
            DrawLine(lineRenderer, endPos, width);

            if(hit.collider)
            {
                // 닿은 물체 처리
                DieSensor dieObj = hit.collider.gameObject.GetComponent<DieSensor>();
                if (dieObj != null)
                    dieObj.InvokeDieEvent();

                // 레이저를 감지하는 블럭에 닿았다면
                CheckLaser checkLaser = hit.collider.gameObject.GetComponent<CheckLaser>();
                if (checkLaser != null)
                    checkLaser.laserCheckEvent?.Invoke();


            }

            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
        }
        UseLineRenderer(lineRenderer, false);
        isShot = false;
    }

    private float easeOutElastic(float x) {
        const float c4 = (2 * Mathf.PI) / 3;

        return x == 0
          ? 0
          : x == 1
          ? 1
          : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }
}
