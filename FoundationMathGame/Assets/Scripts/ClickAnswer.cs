using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is for clicking on 'Enforced Math' questions, the player needs 
// to answer correctly to leave and if the player answers wrong, they'll take damage.
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
        // If the answer is not correct, the player takes damage
        if (!isCorrect)
        {
            WrongAnswerDamage.DealDamage(playerHealth.gameObject);
        }
    }
}