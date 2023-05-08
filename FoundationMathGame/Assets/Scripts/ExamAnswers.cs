using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Exam answers script. 
public class ExamAnswers : MonoBehaviour
{
    public bool isCorrect = false;
    public ExamManager examManager;

    public void Answer()
    {
        if(isCorrect)
        {
            // Question is answered correct, so we move to next question
            examManager.correct();
        }
        else
        {
            // answer is answered wrong, no increment to score/grade, also moves to next question
            examManager.wrong();
        }

    }
}
