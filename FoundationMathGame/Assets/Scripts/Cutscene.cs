using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is to trigger the cutscene player, and trigger the cutscene.
public class Cutscene : MonoBehaviour
{
    public GameObject cutscenePlayer;
    public int videoLength;
    public float secondsRemaining = 23;

    // make sure the cutscene player isn't active automatically
    void Start()
    {
        cutscenePlayer.SetActive(false);
        
    }

    // On trigger collision, it will set the cutscene playe to active,
    // and destroy the cutscene player. This is so we don't activate the 
    // cutscene over and over again when walking through the same area.
    private void OnTriggerEnter(Collider other)
    {
        cutscenePlayer.SetActive(true);
        Destroy(cutscenePlayer, videoLength);
    }

}
