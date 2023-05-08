using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// The exam manager, shell of the exam.
public class ExamManager : MonoBehaviour
{
    public List<ExamQandA> EQandA;
    public GameObject[] option;
    public int currentQ;
    public TMP_Text QuestionText;
    public GameObject ExamPanel;
    public GameObject EndExamPanel;
    public TMP_Text ResultsText;
    // Exam has 50 questions, 40% is needed to pass exam, so 40% of 50 = 20
    public int PassMinimum = 20;
    // The total exam questions is decided in the inspector in Unity
    int totalExamQ = 0;
    public int score;

    private void Start()
    {
        totalExamQ = EQandA.Count;
        generateQ();
        // Unlocks and makes mouse cursor visible upon exam enter
        UnlockMouseCursor(); 
    }

    public void TheEnd()
    {   
        // There are 50 questions, 40% need to be correct to pass
        if (score >= PassMinimum)
        {
            // If pass, the good scene loads with the final cutscene that is happy, then closes the game
            GoodEnd();
        }
        else
        {
            // If exam fails, a cutscene plays immediately and informs you before closing out the game
            BadEnd();
        }
    }

    void EndExam()
    {
        // Swap over the exam canvas panel and show the result panel with the score the player scored in the exam
        ExamPanel.SetActive(false);
        EndExamPanel.SetActive(true);
        ResultsText.text = score + " / " + totalExamQ;
        
    }

    public void GoodEnd()
    {
        // Load scene '5' in build, the good ending (MMU_EndGood)
        SceneManager.LoadScene(5);
    }

    public void BadEnd()
    {
        // Load scene '6' in build, the bad ending (MMU_EndBad)
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
        // Each correct answer had 1 incremented to their final score
        score += 1;
        // remove questin after answering it
        EQandA.RemoveAt(currentQ);
        // generate next question
        generateQ();
    }

    public void wrong()
    {
        // remove question after answering it
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
        // If the number of questions left is more than 0, we still have question(s) available to generate
        if (EQandA.Count > 0)
        {
            // spawn a random question out of the entire list, so students are less likely to be able 
            // to cheat as they can't just write the answers down in chronological order 
            currentQ = Random.Range(0, EQandA.Count);

            QuestionText.text = EQandA[currentQ].Question;
            QAnswer();
        }
        else
        {
            // There's no questions left so the exam ends
            EndExam();
        }
    }
}
