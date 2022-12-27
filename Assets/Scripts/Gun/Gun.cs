using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float Range = 10f;
    [SerializeField] private float VerticalRange = 10f;
    [SerializeField] private float _gunShotRadius = 20f;   
    [SerializeField] private float _damage = 2f;
    [SerializeField] private float _smallDamage = 1f;

    [SerializeField] private float _fireRate = 1f;
    private float _nextTimeToFire;

    public int MaxAmmo;
    private int _ammo;
    
    private BoxCollider _gunTrigger;
    private AudioSource _audioSourse;

    public LayerMask RaycastLayerMask;
    public LayerMask EnemyLayerMask;

    public Animator GunShoot;

    public EnemyManager enemyManager;

    void Start()
    {
        _gunTrigger = GetComponent<BoxCollider>();
        _gunTrigger.size = new Vector3(1, VerticalRange, Range);
        _gunTrigger.center = new Vector3(0, 0, Range * 0.5f);

        _ammo = MaxAmmo;

        _audioSourse = GetComponent<AudioSource>();

        UIManager.Instance.UpdateAmmo(_ammo);
    }

    
    void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.InGame)
        {
            if (Input.GetMouseButtonDown(0) && Time.time > _nextTimeToFire && _ammo > 0)
            {
                Fire();
            }
        }   
    }

    private void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, _gunShotRadius, EnemyLayerMask);

        foreach(var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }
        
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
                }            
            }        
        }
        
        _nextTimeToFire = Time.time + _fireRate;

        _ammo--;

        UIManager.Instance.UpdateAmmo(_ammo);

        GunShoot.SetTrigger("Shoot");
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if(_ammo < MaxAmmo)
        {
            _ammo += amount;
            Destroy(pickup);
        }

        if(_ammo > MaxAmmo)
        {
            _ammo = MaxAmmo;
        }

        UIManager.Instance.UpdateAmmo(_ammo);
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
