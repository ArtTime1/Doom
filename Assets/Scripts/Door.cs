using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator _doorAnimator;

    public bool requeiresKey;
    public bool requeireRed, requeireBlue, requeireGreen;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requeiresKey)
            {
                if(requeireRed && other.GetComponent<PlayerInventory>().hasRedCard)
                {
                    _doorAnimator.SetTrigger("DoorOpen");
                }

                if (requeireBlue && other.GetComponent<PlayerInventory>().hasBlueCard)
                {
                    _doorAnimator.SetTrigger("DoorOpen");
                }

                if (requeireGreen && other.GetComponent<PlayerInventory>().hasGreenCard)
                {
                    _doorAnimator.SetTrigger("DoorOpen");
                }
            }
            else
            {
                _doorAnimator.SetTrigger("DoorOpen");
            }         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requeiresKey)
            {
                if (requeireRed && other.GetComponent<PlayerInventory>().hasRedCard)
                {
                    _doorAnimator.SetTrigger("DoorClose");
                }

                if (requeireBlue && other.GetComponent<PlayerInventory>().hasBlueCard)
                {
                    _doorAnimator.SetTrigger("DoorClose");
                }

                if (requeireGreen && other.GetComponent<PlayerInventory>().hasGreenCard)
                {
                    _doorAnimator.SetTrigger("DoorClose");
                }
            }          
        }
    }
}
