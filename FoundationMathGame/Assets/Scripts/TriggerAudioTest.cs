using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerAudioTest : MonoBehaviour
{
    public AudioObject clipToPlay;
    public bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyPlayed)
        {
            Vocals.instance.Say(clipToPlay);
            alreadyPlayed = true;
        }
        /*  if (!alreadyPlayed)
          {
              audioFile.PlayOneShot(Sound, Volume);
              alreadyPlayed = true;

          }
      }
          public AudioClip Sound;
           public float Volume;
           AudioSource audioFile;
           public bool alreadyPlayed = false;


           // Start is called before the first frame update
           void Start()
           {
               audioFile = GetComponent<AudioSource>();

           }
           private void OnTriggerEnter(Collider other)
           {
               if (!alreadyPlayed)
               {
                   audioFile.PlayOneShot(Sound, Volume);
                   alreadyPlayed = true;

               }*/
    }

}
