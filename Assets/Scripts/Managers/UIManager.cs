using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Armor;
    public TextMeshProUGUI Ammo;

    public Image HealthIndicator;

    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }       
    }

    void Start()
    {
        UpdateHealthIndicator(100);
    }

    public void UpdateHealth(int healthValue)
    {
        Health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
    }

    public void UpdateArmor(int armorValue)
    {
        Armor.text = armorValue.ToString() + "%";
    }

    public void UpdateAmmo(int ammoValue)
    {
        Ammo.text = ammoValue.ToString();
    }

    public void UpdateHealthIndicator(int healthValue)
    {
        if (healthValue >= 66)
        {
            HealthIndicator.sprite = health1;
        }

        if (healthValue < 66 && healthValue >= 33)
        {
            HealthIndicator.sprite = health2;
        }

        if (healthValue < 33 && healthValue > 0)
        {
            HealthIndicator.sprite = health3;
        }

        if(healthValue <= 0)
        {
            HealthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if(keyColor == "red")
        {
            redKey.SetActive(true);
        }

        if (keyColor == "blue")
        {
           blueKey.SetActive(true);
        }

        if (keyColor == "green")
        {
            greenKey.SetActive(true);
        }    
    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        greenKey.SetActive(false);
        blueKey.SetActive(false);
    }
}
