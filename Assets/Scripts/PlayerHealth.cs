using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    private int _health;

    public int MaxArmor;
    private int _armor;

    void Start()
    {
        _health = MaxHealth;
        UIManager.Instance.UpdateHealth(_health);
        UIManager.Instance.UpdateArmor(_armor);
    }

    
    void Update()
    {
        Death();

        
    }

    private void DamagePlayer(int damage)
    {
        if(_armor > 0)
        {
            if(_armor >= damage)
            {
                _armor -= damage;
            }
            else if(_armor < damage)
            {
                int remainingDamage;

                remainingDamage = damage - _armor;

                _armor = 0;

                _health -= remainingDamage;
            }
        }
        else
        {
            _health -= damage;
        }

        UIManager.Instance.UpdateHealth(_health);
        UIManager.Instance.UpdateArmor(_armor);
    }

    private void Death()
    {
        if(_health <= 0)
        {
            Debug.Log("You are dead");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void GiveHealth(int amount, GameObject Pickup)
    {
        if(_health < MaxHealth)
        {
            _health += amount;
            Destroy(Pickup);
        }            

        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        UIManager.Instance.UpdateHealth(_health);
    }

    public void GiveArmor(int amount, GameObject Pickup)
    {
        if(_armor < MaxArmor)
        {
            _armor += amount;
            Destroy(Pickup);
        }    

        if (_armor > MaxArmor)
        {
            _armor = MaxArmor;
        }

        UIManager.Instance.UpdateArmor(_armor);
    }


    private void OnCollisionStay(Collision collision)
    {    
        if(collision.collider.GetComponent<EnemyAI>())
        {
            DamagePlayer(20);          
        }
    }
}
