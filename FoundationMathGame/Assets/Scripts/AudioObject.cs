using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script makes a scriptable object, for adding subtitles and audio to an object.  
[CreateAssetMenu(fileName = "Subtitle Object", menuName = "Assets/SubtitleObject")]
public class AudioObject : ScriptableObject
{
    public AudioClip clip;
    public string subtitle;
    
}
