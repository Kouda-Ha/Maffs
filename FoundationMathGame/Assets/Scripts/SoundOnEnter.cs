using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SoundOnEnter script. This script is to play sound on enter of a trigger/box collider.
public class SoundOnEnter : MonoBehaviour
{
    public AudioClip Sound;
    public float Volume;
    AudioSource audioFile;
    public bool alreadyPlayed = false;

    void Start()
    {
        audioFile = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // If it hasn't already been played, then play the audio
        if (!alreadyPlayed)
        {
            audioFile.PlayOneShot(Sound, Volume);
            alreadyPlayed = true;
        }
    }
}
