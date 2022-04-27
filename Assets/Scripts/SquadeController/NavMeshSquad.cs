using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSquad : MonoBehaviour
{
    [SerializeField] private NavMeshAgent[] _agents;
    private ISquadePositionGenerator _generator;
    public Transform Target;

    private void Awake()
    {
        _generator = GetComponent<ISquadePositionGenerator>();
        
        Target.GetOrAddComponent<Transform,ObserverableTransform>().OnChangePosition += (target) =>
        {
            SetSquadCenter(target.position);
        };
    }

    private void SetSquadCenter(Vector3 center)
    {
        var positions = _generator.GetPosition(_agents.Length);
        for (int i = 0; i < positions.Length; i++)
        {
            _agents[i].SetDestination(center + (positions[i]*3));
        }
    }
}
