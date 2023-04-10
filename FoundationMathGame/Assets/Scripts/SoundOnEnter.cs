using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnEnter : MonoBehaviour
{
    public AudioClip Sound;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(Sound, Volume);
            alreadyPlayed = true;

        }
    }
}
