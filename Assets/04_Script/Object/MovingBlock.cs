using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    enum MoveState
    {
        None,
        MovePoint1,
        MovePoint2,
    }

    private float _movingSpeed = 5f;

    private Vector2 _point1;
    [SerializeField] private Vector2 _point2;

    private LineRenderer _lineRenderer;

    private MoveState _moveState = MoveState.MovePoint2;
    private Vector2 _dir; 

    private void Awake()
    {
        SetPosLineRenderer();

        StartCoroutine("");
    }

    IEnumerator MovingCo()
    {
        while(true)
        {



            yield return new WaitForEndOfFrame();
        }
    }

    [ContextMenu("SetPosLineRenderer")]
    public void SetPosLineRenderer()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _point1 = transform.position;

        _lineRenderer.SetPosition(0, _point1);
        _lineRenderer.SetPosition(1, _point2);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, _point2);
    }
}
