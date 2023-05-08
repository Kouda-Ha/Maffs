using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Derived from Advanced Games Design 'P.E.T.S Zoo Simulator' game code 'pcController.cs'
// This is for using the optional PCs that have tips on them. 
public class InteractScreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pcCam;
    [SerializeField] private GameObject playerCvs;

    void Start()
    {
        pcCam.GetComponent<Camera>().enabled = false;
    }

    private void OnTriggerStay(Collider collider)
    {
        // If the player is in the collider area and presses 'E' they'll go into the viewpoint
        // of the PC screen and read a tip, or 'F' to leave said PC after viewing.
        if (collider.gameObject.CompareTag("Player"))
        {
            // 'E' to Enter the Interaction Screen
            if (Input.GetKey(KeyCode.E))
            {
                playerCvs.SetActive(false);
                player.GetComponent<FirstPersonController>().enabled = false;
                player.GetComponentInChildren<Camera>().enabled = false;
                pcCam.GetComponent<Camera>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            // 'F' to Finish using the Interaction Screen
            else if (Input.GetKey(KeyCode.F))
            {
                playerCvs.SetActive(true);
                player.GetComponent<FirstPersonController>().enabled = true;
                player.GetComponentInChildren<Camera>().enabled = true;
                pcCam.GetComponent<Camera>().enabled = false;
            }
        }
    }
}
