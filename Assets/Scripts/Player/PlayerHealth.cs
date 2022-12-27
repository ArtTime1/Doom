using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    private int _health;

    private double timer = 2;
    private double _HitRate = 2;

    public GameObject Restart;
    public GameObject PlayerUI;

    public int MaxArmor;
    private int _armor;

    private void OnEnable()
    {
        _health = MaxHealth;
    }

    private void Start()
    {
        if (UIManager.Instance)
        {
        UIManager.Instance.UpdateHealth(_health);
        UIManager.Instance.UpdateArmor(_armor);

        }
    }

    void Update()
    {
        Death();        
    }

    /*public int Health
    {
        get => _health;
        set
        {
            if (value <= 0)
            {
                _health = value;
                Death();
            }
        }

    }*/

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
                //Health -= remainingDamage;
            }
        }
        else
        {
            _health -= damage;
            //Health -= damage;
        }

        UIManager.Instance.UpdateHealth(_health);
        UIManager.Instance.UpdateArmor(_armor);
    }

    private void Death()
    {
        if(_health <= 0)
        {
            Debug.Log("You are dead");

            Restart.SetActive(true);
            PlayerUI.SetActive(false);
            Time.timeScale = 0.0f;
            GameManager.Instance.State = GameManager.GameState.InGame_dead;
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

        if (timer >= _HitRate && collision.collider.GetComponent<EnemyAI>())
        {
            DamagePlayer(20);

            timer = 0;
        }


        timer += Time.deltaTime;
    }

    private void OnCollisionExit(Collision collision)
    {
        timer = _HitRate;
    }

}
