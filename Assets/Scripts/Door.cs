using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator _doorAnimator;

    private AudioSource _audioSource;
    public AudioClip[] AudioClip;
    public bool requeiresKey;
    public bool requeireRed, requeireBlue, requeireGreen;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requeiresKey)
            {
                if(requeireRed && other.GetComponent<PlayerInventory>().hasRedCard)
                {
                    PlayAnimationAndClip("DoorOpen", AudioClip[0]);
                }

                if (requeireBlue && other.GetComponent<PlayerInventory>().hasBlueCard)
                {
                    PlayAnimationAndClip("DoorOpen", AudioClip[0]);
                }

                if (requeireGreen && other.GetComponent<PlayerInventory>().hasGreenCard)
                {
                    PlayAnimationAndClip("DoorOpen", AudioClip[0]);
                }
            }
            else
            {
                PlayAnimationAndClip("DoorOpen", AudioClip[0]);
            }         
        }
    }

    private void PlayAnimationAndClip(string animName, AudioClip audioClip )
    {
        _doorAnimator.SetTrigger(animName);
        _audioSource.PlayOneShot(audioClip);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requeiresKey)
            {
                if (requeireRed && other.GetComponent<PlayerInventory>().hasRedCard)
                {
                    PlayAnimationAndClip("DoorClose", AudioClip[1]);
                }

                if (requeireBlue && other.GetComponent<PlayerInventory>().hasBlueCard)
                {
                    PlayAnimationAndClip("DoorClose", AudioClip[1]);
                }

                if (requeireGreen && other.GetComponent<PlayerInventory>().hasGreenCard)
                {
                    PlayAnimationAndClip("DoorClose", AudioClip[1]);
                }           
            }

            if (!requeiresKey)
            {
                PlayAnimationAndClip("DoorClose", AudioClip[1]);
            }
        }
    }
}
