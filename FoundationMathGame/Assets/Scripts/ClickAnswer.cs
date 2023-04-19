using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnswer : MonoBehaviour
{
    private Renderer render;
    private int clickCount = 0;

    public int GetNumClicks()
    {
        // return the number of clicks since the last query
        int clicks = clickCount;
        clickCount = 0;
        return clicks;
    }

    void OnMouseDown()
    {
        clickCount++;
    }
}