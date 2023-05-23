using System;
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

    private LineRenderer _lineRenderer;

    [Header("현재 위치에서 얼마나 이동하는지")]
    [SerializeField] private Vector2 _moveTo;
    private Vector2 _point1;
    private Vector2 _point2;

    private MoveState _moveState = MoveState.MovePoint2;
    private Vector3 _dir;
    private float _movingSpeed = 3f;

    private BoxCollider2D _colider;
    private readonly float _correctNum = 0.1f;
    [Header("체크 안 할 오브젝트 이름 리스트")]
    [SerializeField] private List<string> _notCheckColList;

    private void Awake()
    {
        _colider = GetComponent<BoxCollider2D>();
        SetPosLineRenderer();
    }

    private void Update()
    {
        MoveBlock();
    }

    private void MoveBlock()
    {
        //현재 이동중인 포인트 방향 체크
        Vector3 movePoint = Vector3.zero;
        Vector3 pos = transform.position;

        if (_moveState == MoveState.MovePoint1)
            movePoint = _point1;
        else if (_moveState == MoveState.MovePoint2)
            movePoint = _point2;

        movePoint.z = 0;
        pos.z = 0;

        _dir = (movePoint - pos).normalized;
        Vector3 moveVec = _dir * _movingSpeed * Time.deltaTime;

        //닿은 오브젝트 이동, 차후에 렉 or 프레임 드랍이 일어난다면 LineCastAll로 수정
        RaycastHit2D[] hits = Physics2D.BoxCastAll(pos + Vector3.up * _correctNum, _colider.size - (Vector2.one * _correctNum), 0, Vector2.zero);
        List<Transform> hitTrms = new List<Transform>();

        //닿은 콜라이더의 오브젝트들을 하위 오브젝트로
        foreach (var hitObj in hits)
        {
            bool notCheck = false;
            for(int i = 0; i < _notCheckColList.Count; i++)
            {
                if(hitObj.transform.name == _notCheckColList[i])
                {
                    notCheck = true;
                    break;
                }
            }

            if (notCheck) continue;

            hitTrms.Add(hitObj.transform);
            hitObj.transform.SetParent(transform);
        }
            

        //블럭 이동
        transform.position = pos + moveVec;

        //닿은 콜라이더의 오브젝트들을 하위 오브젝트로 해제
        foreach (var hitObj in hitTrms)
            hitObj.SetParent(null);

        //도착 체크
        if ((transform.position - movePoint).sqrMagnitude < 0.025)
        {
            //transform.position = movePoint;
            _moveState = ((_moveState == MoveState.MovePoint1) ? MoveState.MovePoint2 : MoveState.MovePoint1);
        }
    }

    [ContextMenu("SetPosLineRenderer")]
    public void SetPosLineRenderer()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _point1 = transform.position;
        _point2 = transform.position + (Vector3)_moveTo;

        _lineRenderer.SetPosition(0, _point1);
        _lineRenderer.SetPosition(1, _point2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        _colider = GetComponent<BoxCollider2D>();
        Gizmos.DrawWireCube(transform.position + Vector3.up * _correctNum, _colider.size - Vector2.one * _correctNum);
    }
}
