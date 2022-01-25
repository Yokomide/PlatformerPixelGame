using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds: MonoBehaviour
{
    private AudioSource randomSound;

    public AudioClip[] audioSources;

    // Use this for initialization
    void Start()
    {
        randomSound = GetComponent<AudioSource>();
        CallAudio();
    }
    public void HitSound()
    {
        randomSound.clip = audioSources[Random.Range(1, audioSources.Length)];
        randomSound.Play();

    }

    void CallAudio()
    {
        Invoke("RandomSoundness", 5);
    }

    void RandomSoundness()
    {
        randomSound.clip = audioSources[0];
        randomSound.Play();
        CallAudio();
    }
}
