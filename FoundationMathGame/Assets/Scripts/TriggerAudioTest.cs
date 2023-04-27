using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerAudioTest : MonoBehaviour
{
    public AudioObject clipToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Vocals.instance.Say(clipToPlay);
    }
}
