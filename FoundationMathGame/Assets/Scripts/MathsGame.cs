using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MathsGame : MonoBehaviour
{
    ClickAnswer [] answers;
    GrabCamera gameCamera;
    bool beaten = false;
    
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
        foreach (var answer in answers)
        {
            if (answer.GetNumClicks() > 0)
            {
                anyClicked = true;
            }
        }

        if (anyClicked)
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
