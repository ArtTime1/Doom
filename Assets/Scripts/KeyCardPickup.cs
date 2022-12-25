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
            }

            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlueCard = true;
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreenCard = true;
            }

            Destroy(this.gameObject);
        }
    }
}
