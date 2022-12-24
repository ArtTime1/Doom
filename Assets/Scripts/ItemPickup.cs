using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;

    public PlayerHealth _playerHealth;
    public Gun gun;

    public int amount;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                _playerHealth.GiveHealth(amount, this.gameObject);
            }

            if (isArmor)
            {
                _playerHealth.GiveArmor(amount, this.gameObject);
            }

            if (isAmmo)
            {
                gun.GiveAmmo(amount, this.gameObject);
            }       
        }
    }
}
