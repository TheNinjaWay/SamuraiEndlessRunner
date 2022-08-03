using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Pickup;
    public AudioClip Runing;
    public AudioClip Jump;

    public void PlayPickup()
    {
        audioSource.clip = Pickup;
        audioSource.Play();
    }
    public void PlayRuning()
    {
        audioSource.clip = Runing;
        audioSource.Play();
    }
    public void PlayJump()
    {
        audioSource.clip = Jump;
        audioSource.Play();
    }
}
