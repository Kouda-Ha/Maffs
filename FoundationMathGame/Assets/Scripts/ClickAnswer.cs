using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    public Color color;
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