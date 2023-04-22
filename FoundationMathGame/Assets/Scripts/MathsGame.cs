using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MathsGame : MonoBehaviour
{
    ClickAnswer [] answers;
    GrabCamera gameCamera;
    bool beaten = false;
    public HealthManager playerHealth;

    // Start is called before the first frame update
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
        {
            if (answer.GetNumClicks() > 0)
            {
                anyClicked = true;
                if (answer.isCorrect == true)
                {
                    correctClicked = true;
                }
            }
        }
        if (anyClicked && playerHealth.health <= 0)
        {
            gameCamera.ReleaseCamera();
        }
        if (correctClicked)
        {
            gameCamera.ReleaseCamera();
            beaten = true;  
        } 

    }

    private void OnTriggerEnter(Collider col)
    {
        if (!beaten && col.gameObject.tag == "Player")
        {
            GetComponent<GrabCamera>().GrabCameraFrom(col.gameObject);
        }
    }
}
