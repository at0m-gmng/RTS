using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverableTransform : MonoBehaviour
{
    public event Action<Transform> OnChangePosition;
    private Vector3 _lastPos;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _lastPos = _transform.position;
    }

    private void Update()
    {
        if (_transform.position != _lastPos)
        {
            if (OnChangePosition != null)
            {
                OnChangePosition.Invoke(_transform);
            }
        }

        _lastPos = _transform.position;
    }
}
