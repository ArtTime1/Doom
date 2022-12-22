using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float Range = 20f;
    [SerializeField] private float VerticalRange = 20f;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _damage = 2f;
    [SerializeField] private float _smallDamage = 1f;

    private float _nextTimeToFire;
    private BoxCollider _gunTrigger;
    private AudioSource _audioSourse;

    public LayerMask RaycastLayerMask;
    public EnemyManager enemyManager;

    void Start()
    {
        _gunTrigger = GetComponent<BoxCollider>();
        _gunTrigger.size = new Vector3(1, VerticalRange, Range);
        _gunTrigger.center = new Vector3(0, 0, Range * 0.5f);

        _audioSourse = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > _nextTimeToFire)
        {          
            Fire();
        }
    }

    private void Fire()
    {
        _audioSourse.Play();
        
        foreach(var enemy in enemyManager.EnemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;
            
            RaycastHit hit;
            if(Physics.Raycast(transform.position, dir, out hit, Range * 1.5f, RaycastLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    float distance = Vector3.Distance(enemy.transform.position, transform.position);
                    if (distance > Range * 0.5f)
                    {
                        enemy.TakeDamage(_smallDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(_damage);
                    }
                    
                    enemy.TakeDamage(_damage);
                }            
            }        
        }
        
        _nextTimeToFire = Time.time + _fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
