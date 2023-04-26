using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Subtitle Object", menuName = "Assets/SubtitleObject")]

public class AudioObject : ScriptableObject
{
    public AudioClip clip;
    public string subtitle;
    
}
