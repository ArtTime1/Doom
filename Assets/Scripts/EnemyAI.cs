using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness _enemyAwareness;
    private NavMeshAgent _enemyNavMeshAgent;

    private Rigidbody _rigidbody;
    public float moveSpeed = 8f;

    
    void Start()
    {
        _enemyAwareness = GetComponent<EnemyAwareness>();
        //_enemyNavMeshAgent = GetComponent<NavMeshAgent>();

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_enemyAwareness.isAggro)
        {
            //_enemyNavMeshAgent.SetDestination(_enemyAwareness._playersTransform.position);

            Vector3 playerDirection = PlayerMovement._playerMovement.transform.position - transform.position;
            _rigidbody.velocity = playerDirection.normalized * moveSpeed;
        }
        else
        {
            // _enemyNavMeshAgent.SetDestination(transform.position);
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
       
    }
}
