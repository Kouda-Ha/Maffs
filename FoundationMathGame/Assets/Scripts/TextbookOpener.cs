using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TextbookOpener script. Very basic script that will turn on and off the canvas holding the textbook
public class TextbookOpener : MonoBehaviour
{
    [SerializeField] private GameObject textbookCanvas;
    
    void Start()
    {
        // Textbook is inactive at start
        textbookCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenHandbook();

    }

    private void OpenHandbook()
    {
        // When you press 'T', if the textbook canvas isn't already activated
        // then the textbook canvas is activated
        if (Input.GetKeyDown(KeyCode.T))
        {
            textbookCanvas.SetActive(!textbookCanvas.activeInHierarchy);
        }
    }
}