using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// SubtitleUI script. This script is to place subtitles on the player's canvas so when an
// audio clip is triggered it also shows up the subtitles, for accessibility reasons.
public class SubtitleUI : MonoBehaviour
{
    [SerializeField] TextMeshPro subtitleText = default;
    public static SubtitleUI instance;

    public void Awake()
    {
        instance = this;
        ClearSubtitle();
    }

    public void SubtitlesText(string subtitle, float delay)
    {
        // Subtitle text in each of the audio objects in Unity inspector
        subtitleText.text = subtitle;
        // Start the delay in clearing it again, that waits for end of audio clip
        StartCoroutine(ClearAfterSeconds(delay));
    }

    // Changes the subtitle to blank/empty "" so it isn't visible anymore
    public void ClearSubtitle()
    {
        subtitleText.text = "";
    }

    // Wait for the amount of seconds the audio is for, then "clear" the subtitles too
    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
}
