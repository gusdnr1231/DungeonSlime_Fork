using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    private int _crtGotoPosIdx = 1;
    private bool _isBack = false;

    [Header("이동 포지션 순서")]
    [SerializeField]
    private List<Vector2> _points = new List<Vector2>();

    [Header("라인 렌더러 사용여부")]
    [SerializeField]
    private bool _useLineRenderer = true;
    private LineRenderer _lineRenderer;

    Transform _trm;

    [Header("속도 정보")]
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private float _moveSpeed;

    private float _rotationValue = 0;

    private void Awake()
    {
        _trm = transform;

        SetPosLineRenderer();
    }

    private void Update()
    {
        RotateSaw();
        MoveSaw();
    }

    private void RotateSaw()
    {
        _trm.rotation = Quaternion.Euler(0, 0, _rotationValue);
        _rotationValue = _rotationValue + _rotateSpeed * Time.deltaTime;
    }

    private void MoveSaw()
    {
        //현재 이동중인 포인트 방향 체크
        Vector3 pos = transform.position;
        Vector3 movePoint = Vector3.zero;
        movePoint = _points[_crtGotoPosIdx % _points.Count];

        movePoint.z = 0;
        pos.z = 0;

        Vector3 dir = (movePoint - pos).normalized;
        Vector3 moveVec = dir * _moveSpeed * Time.deltaTime;

        //블럭 이동
        transform.position = pos + moveVec;

        //도착 체크
        if ((transform.position - movePoint).sqrMagnitude < 0.01)
        {
            transform.position = _points[_crtGotoPosIdx];

            if (_crtGotoPosIdx == _points.Count - 1)
                _isBack = true;
            else if (_crtGotoPosIdx == 0)
                _isBack = false;

            // 방향
            if(_isBack == false)
                _crtGotoPosIdx++;
            else
                _crtGotoPosIdx--;
        }
    }

    [ContextMenu("SetPosLineRenderer")]
    public void SetPosLineRenderer()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = _useLineRenderer;

        transform.position = _points[0];

        _lineRenderer.positionCount = _points.Count;
        for (int i = 0; i < _points.Count; i++)
            _lineRenderer.SetPosition(i, _points[i]);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < _points.Count; i++)
        {
            Gizmos.DrawSphere(_points[i], 0.1f);
        }
    }
}
