using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _enemyHealth = 2f;
    public EnemyManager enemyManager;

    private AudioSource _audioSource;
    public AudioClip AudioClip;

    public GameObject GunHitEffect;
  

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();      
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
        Instantiate(GunHitEffect, transform.position, Quaternion.identity);
        _enemyHealth -= damage;       
    }
}
