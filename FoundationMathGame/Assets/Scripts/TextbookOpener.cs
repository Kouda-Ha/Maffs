using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextbookOpener : MonoBehaviour
{
    [SerializeField] private GameObject textbookCanvas;
    
    void Start()
    {
        textbookCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenHandbook();
    }

    private void OpenHandbook()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("hello");
            textbookCanvas.SetActive(!textbookCanvas.activeInHierarchy);

        }
    }
}