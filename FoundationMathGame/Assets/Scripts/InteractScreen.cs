using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;

// Derived from Advanced Games Design 'P.E.T.S Zoo Simulator code pcController.cs'
public class InteractScreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pcCam;
    [SerializeField] private GameObject playerCvs;
    private Coroutine zoomCoroutine;
    private float targetFOV = 20, startFOV = 60;
    private float counter = 0;

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
                counter = 0;
                playerCvs.SetActive(false);
                player.GetComponent<FirstPersonController>().enabled = false;
                player.GetComponentInChildren<Camera>().enabled = false;
                pcCam.GetComponent<Camera>().enabled = true;
            
            }
            // 'F' to Finish using the Interaction Screen
            else if (Input.GetKey(KeyCode.F)) 
            {
                if (zoomCoroutine != null)
                    StopCoroutine(zoomCoroutine);
                pcCam.GetComponent<Camera>().fieldOfView = 60;
                playerCvs.SetActive(true);
                player.GetComponent<FirstPersonController>().enabled = true;
                player.GetComponentInChildren<Camera>().enabled = true;
                pcCam.GetComponent<Camera>().enabled = false;
            }

        }

    }

}
