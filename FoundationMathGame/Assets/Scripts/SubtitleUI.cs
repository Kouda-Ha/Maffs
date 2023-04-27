using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        subtitleText.text = subtitle;

        StartCoroutine(ClearAfterSeconds(delay));
    }

    public void ClearSubtitle()
    {
        subtitleText.text = "";
    }

    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
}
