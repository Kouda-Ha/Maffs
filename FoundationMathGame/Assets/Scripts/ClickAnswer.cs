using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnswer : MonoBehaviour
{
    public HealthManager playerHealth;
    public HealthManager WrongAnswerDamage;
    private Renderer render;
    private int clickCount = 0;
    [SerializeField] public bool isCorrect=false;

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
        if (!isCorrect)
        {
            WrongAnswerDamage.DealDamage(playerHealth.gameObject);
        }
    }
}