using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject cutscenePlayer;
    public int videoLength;

    // Start is called before the first frame update
    void Start()
    {
        cutscenePlayer.SetActive(false);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        cutscenePlayer.SetActive(true);
        Destroy(cutscenePlayer, videoLength);
    }
}
