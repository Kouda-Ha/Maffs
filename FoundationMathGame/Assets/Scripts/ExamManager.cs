using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// The exam manager, shell of exam
public class ExamManager : MonoBehaviour
{
    public List<ExamQandA> EQandA;
    public GameObject[] option;
    public int currentQ;
    public TMP_Text QuestionText;

    private void Start()
    {
        generateQ();
        UnlockMouseCursor(); // Unlock and make cursor visible upon exam enter
    }

    // Very important! If it isn't unlocked and visible upon
    // entering the exam scene, the player can not click an answer
    // and is soft-locked in the game for eternity.
    void UnlockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void correct()
    {
        // remove Q after answering it
        EQandA.RemoveAt(currentQ);
        // generate next question
        generateQ();

    }

    // Getting text from child of buttons A,B,C,D and setting it to that of the EQandA script
    void QAnswer()
    {
        for (int i = 0; i < option.Length; i++)
        {
            // start false so it isn't marked correct whiles loading next question / etc
            option[i].GetComponent<ExamAnswers>().isCorrect = false;
            option[i].transform.GetChild(0).GetComponent<TMP_Text>().text = EQandA[currentQ].Answer[i];

            if (EQandA[currentQ].CorrectAns == i+1)
            {
                option[i].GetComponent<ExamAnswers>().isCorrect = true;
            }

        }
    }

    // Generate Question
    void generateQ()
    {
        currentQ = Random.Range(0, EQandA.Count);

        QuestionText.text = EQandA[currentQ].Question;
        QAnswer();

    }

}
