using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script waits for several seconds before doing the next action, which is to close the application/game entirely.
// The cutscenes playing during this wait time, are around 7 seconds each, at the very end of the game, depending on exam score
public class WaitThenQuitGame : MonoBehaviour
{
    // Wait time in the coroutine
    public int waitTime = 7;

    // On trigger enter, the game starts this coroutine
    public void OnTriggerEnter(Collider collision)
    {
        StartCoroutine(CutsceneWaitCoroutine());
    }

        // Cutscene(s) are triggered at the same time, in another script, this is waiting for specified
        //seconds before closing application.  
        IEnumerator CutsceneWaitCoroutine()
        {
            //yield on a new YieldInstruction that waits for x seconds.
            yield return new WaitForSeconds(waitTime);
            // After said x seconds, the game quits/closes on the player
            Application.Quit();
        }
    
}
