using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Derived from Advanced Games Design 'P.E.T.S Zoo Simulator code pcController.cs'
public class InteractScreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pcCam;
    [SerializeField] private GameObject playerCvs;

    // Start is called before the first frame update
    void Start()
    {
        pcCam.GetComponent<Camera>().enabled = false;
    }

    private void OnTriggerStay(Collider collider)
    {
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
