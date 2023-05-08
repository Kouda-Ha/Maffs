using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Derived from Advanced Games Development, Week 1 Part 4 Lab Materials
// Found here: https://moodle.mmu.ac.uk/mod/page/view.php?id=3654322
public class GrabCamera : MonoBehaviour
{
    private bool hasCamera = false;
    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    private Transform theCamera = null;
    private GameObject thePlayer = null;

    public float blendFac = 0.05f;

    void Start()
    {
        // Find camera and/or children
        // Save camera position/rotation, references cam object
        Camera camComponent = GetComponentInChildren<Camera>();
        theCamera = camComponent.transform;
        cameraPosition = theCamera.position;
        cameraRotation = theCamera.rotation;
        // Disable camera
        theCamera.GetComponent<Camera>().enabled = false;

    }

    IEnumerator ReleaseOverTime()
    {
        hasCamera = false;
        Camera playerCamComponent = thePlayer.GetComponentInChildren<Camera>();
        Transform playerCamera = playerCamComponent.transform;

        Vector3 targetPos = playerCamera.position;
        Quaternion targetRot = playerCamera.rotation;

        bool done = false;
        while (!done)
        {
            Vector3 curPos = theCamera.position;
            Quaternion curRot = theCamera.rotation;
            // blends towards target
            curPos = Vector3.Lerp(curPos, targetPos, blendFac);
            curRot = Quaternion.Slerp(curRot, targetRot, blendFac);
            theCamera.position = curPos;
            theCamera.rotation = curRot;
            done = (targetPos - curPos).sqrMagnitude < 0.001f && Quaternion.Dot(targetRot, curRot) > 0.999f;
            yield return null;  
        }

        // gives player back control and disables camera
        // enables camera in object
        theCamera.GetComponent<Camera>().enabled = false;
        thePlayer.SetActive(true);
    }

    public void ReleaseCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // give player back their camera
        StartCoroutine(ReleaseOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCamera)
        {
            // get current rotation and position of the camera
            Vector3 curPos = theCamera.position;
            Quaternion curRot = theCamera.rotation;
            // blend towards target
            curPos = Vector3.Lerp(curPos, cameraPosition, blendFac);
            curRot = Quaternion.Slerp(curRot, cameraRotation, blendFac);
            theCamera.position = curPos;
            theCamera.rotation = curRot;
        }
    }

    // Grab camera from the player
    public void GrabCameraFrom(GameObject player)
    {
        // switch off player control
        thePlayer = player;
        player.SetActive(false);
        // enable cam object
        theCamera.GetComponent<Camera>().enabled = true;
        // copy cam pos and rot from player
        Camera playerCamComponent = player.GetComponentInChildren<Camera>();
        Transform playerCamera = playerCamComponent.transform;
        theCamera.position = playerCamera.position;
        theCamera.rotation = playerCamera.rotation;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        hasCamera = true;
    }
}
