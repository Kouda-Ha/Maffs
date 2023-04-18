using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExamAnswers : MonoBehaviour
{

    public bool isCorrect = false;
    public ExamManager examManager;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("good job");
            // Question is answered correct, so we move to next question
            examManager.correct();
        }
        else
        {
            Debug.Log("wrong");
            // answer answered wrong, no increment to score/grade
            examManager.wrong();
        }

    }
}
