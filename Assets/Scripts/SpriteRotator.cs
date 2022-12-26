using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour
{   
 
    void Update()
    {
        transform.LookAt(PlayerMovement._playerMovement.transform.position);
    }
}
