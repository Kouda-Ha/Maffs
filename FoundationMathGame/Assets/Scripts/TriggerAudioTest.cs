using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// TriggerAudioTest script. A very simple script where if you're tagged as player and the audio has not 
// already been triggered, then the audio will trigger
public class TriggerAudioTest : MonoBehaviour
{
    public AudioObject clipToPlay;
    public bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        // When colliding in trigger box/collision area,
        // if tagged as 'Player' and the sound hasn't already played then play it
        if (other.CompareTag("Player") && !alreadyPlayed)
        {
            Vocals.instance.Say(clipToPlay);
            alreadyPlayed = true;
        }
    }
}
