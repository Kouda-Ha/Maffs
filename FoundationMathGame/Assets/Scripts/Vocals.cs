using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vocals : MonoBehaviour
{
    private AudioSource source;
    public static Vocals instance;

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
        if (source.isPlaying)
        {
            source.Stop();
        }
        source.PlayOneShot(clip.clip);
        SubtitleUI.instance.SubtitlesText(clip.subtitle, clip.clip.length);
    }

}
