using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _enemyHealth = 2f;
    public EnemyManager enemyManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(_enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage (float damage)
    {
        _enemyHealth -= damage;
    }
}
