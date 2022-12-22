using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness _enemyAwareness;
    private NavMeshAgent _enemyNavMeshAgent;
    
    void Start()
    {
        _enemyAwareness = GetComponent<EnemyAwareness>();
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyAwareness.isAggro)
        {
            _enemyNavMeshAgent.SetDestination(_enemyAwareness._playersTransform.position);
        }
        else
        {
            _enemyNavMeshAgent.SetDestination(transform.position);
        }
    }


}
