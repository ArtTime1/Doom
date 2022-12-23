using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    private int _health;

    public int maxArmor;
    private int _armor;

    void Start()
    {
        _health = MaxHealth;
        _armor = maxArmor;
    }

    
    void Update()
    {
        Death();

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DamagePlayer(30);
            Debug.Log("Player has been damaged");
        }
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
}