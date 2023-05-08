using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// The exam manager, shell of exam
public class ExamManager : MonoBehaviour
{
    public List<ExamQandA> EQandA;
    public GameObject[] option;
    public int currentQ;
    public TMP_Text QuestionText;
    public GameObject ExamPanel;
    public GameObject EndExamPanel;
    public TMP_Text ResultsText;
    public int PassMinimum = 20; // Exam has 50 questions, 40% is needed to pass exam, so 40% of 50 = 20

    int totalExamQ = 0;
    public int score;

    private void Start()
    {
        totalExamQ = EQandA.Count;
        generateQ();
        UnlockMouseCursor(); // Unlock and make cursor visible upon exam enter
    }

    public void TheEnd()
    {   
        // There are 50 questions, 40% need to be correct to pass
        if (score >= PassMinimum)
        {
            GoodEnd();
        }
        else
        {
            BadEnd();
        }
    }

    void EndExam()
    {
        ExamPanel.SetActive(false);
        EndExamPanel.SetActive(true);
        ResultsText.text = score + " / " + totalExamQ;
        
    }

    public void GoodEnd()
    {
        Debug.Log("Congrats! You passed!");
        SceneManager.LoadScene(5);
    }

    public void BadEnd()
    {
        Debug.Log("Bad End! You failed!");
        SceneManager.LoadScene(6);
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
        score += 1;
        // remove Q after answering it
        EQandA.RemoveAt(currentQ);
        // generate next question
        generateQ();
    }

    public void wrong()
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
        // If the count is > 0, we still have question(s) available to generate
        if (EQandA.Count > 0)
        {
            currentQ = Random.Range(0, EQandA.Count);

            QuestionText.text = EQandA[currentQ].Question;
            QAnswer();
        }
        else
        {
            Debug.Log("no Q's left");
            EndExam();
        }
    }
}
