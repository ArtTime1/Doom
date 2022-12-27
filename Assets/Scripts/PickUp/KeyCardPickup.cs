using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPickup : MonoBehaviour
{
    public bool isRedKey, isBlueKey, isGreenKey;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRedCard = true;
                UIManager.Instance.UpdateKeys("red");               
            }

            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlueCard = true;
                UIManager.Instance.UpdateKeys("blue");                
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreenCard = true;
                UIManager.Instance.UpdateKeys("green");             
            }

            Destroy(this.gameObject);
        }     
    }
}
