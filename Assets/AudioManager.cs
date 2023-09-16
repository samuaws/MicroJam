using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip dash;
    public AudioClip invisible;
    public AudioClip grapple;
    public AudioClip fireball;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySoundEffect(Abilities ability)
    {
        switch (ability) 
        {
            case Abilities.dash:
                audioSource.clip = dash;
                break;
            case Abilities.invisible: 
                audioSource.clip = invisible; 
                break;
            case Abilities.grappel: 
                audioSource.clip = grapple; 
                break;
            case Abilities.fireBall: 
                audioSource.clip = fireball;   
                break;
        }
        audioSource.Play();
    }


}
