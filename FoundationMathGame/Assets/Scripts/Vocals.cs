using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

// Vocals script. A script to help with subtitles and audio sources. Similar to the one used in the tutorial.
public class Vocals : MonoBehaviour
{
    private AudioSource source;
    public static Vocals instance;
    public bool alreadyPlayed = false;
    public void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(AudioObject clip)
    {
        // If the source is playing and hasn't played yet, then change alreadyPlayed to true
        if (source.isPlaying && !alreadyPlayed)
        {
            alreadyPlayed = true;
            source.Stop();
        }
        // Play the clip once and display it's subtitles
        source.PlayOneShot(clip.clip);
        SubtitleUI.instance.SubtitlesText(clip.subtitle, clip.clip.length);
    }
}
