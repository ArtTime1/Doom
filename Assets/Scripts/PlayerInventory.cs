using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasGreenCard, hasRedCard, hasBlueCard;  
   
    void Start()
    {
        UIManager.Instance.ClearKeys();
    }

    
}
