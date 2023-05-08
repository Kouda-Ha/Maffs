using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// Maths Game script. Player is forced to answer a math question,
// can only leave the PC once correctly answering the question. 
public class MathsGame : MonoBehaviour
{
    ClickAnswer [] answers;
    GrabCamera gameCamera;
    bool beaten = false;
    public HealthManager playerHealth;

    void Start()
    {
        answers = GetComponentsInChildren<ClickAnswer>();
        gameCamera = GetComponent<GrabCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        bool anyClicked = false;
        bool correctClicked = false;
        foreach (var answer in answers)
        {   // If you've clicked an answer and it's correct, then change correct clicked to true
            if (answer.GetNumClicks() > 0)
            {
                anyClicked = true;
                if (answer.isCorrect == true)
                {
                    correctClicked = true;
                }
            }
        }
        // If anything is clicked and as long as player health is less that (or equal to) 0/dead,
        // release the camera
        if (anyClicked && playerHealth.health <= 0)
        {
            gameCamera.ReleaseCamera();
        }
        // If the correct answer is clicked, release the camera
        if (correctClicked)
        {
            gameCamera.ReleaseCamera();
            beaten = true;  
        } 

    }

    // On trigger enter of collision box, if the question isn't answered correctly yet and
    // user is tagged player, make them answer that question by grabbing the camera
    private void OnTriggerEnter(Collider col)
    {
        if (!beaten && col.gameObject.tag == "Player")
        {
            GetComponent<GrabCamera>().GrabCameraFrom(col.gameObject);
        }
    }
}
