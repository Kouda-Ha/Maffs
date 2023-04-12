using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class buttonHelper : MonoBehaviour
{
    public GameObject button;
    //public GameObject Book;
    private bool bookActive = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            bookActive = !bookActive;
            button.gameObject.SetActive(true);

        }
        else
        {
            button.gameObject.SetActive(false);

        }
    }

   
    public void OpenBook()
    {
        {
            if(button.activeInHierarchy == false)
            {
                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }
        }
    }
}
