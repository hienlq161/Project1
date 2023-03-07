using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
   
    private AudioSource audi;
    void Awake()
    {
        audi = GetComponent<AudioSource>();
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
    }
    
    public void PlaySound(AudioClip _sound)
    {
        audi.PlayOneShot(_sound);
    }
    public void OnPauseState()
    {
        audi.Pause();
    }
    public void OnCountinueState()
    {
        audi.Play();
    }
}
