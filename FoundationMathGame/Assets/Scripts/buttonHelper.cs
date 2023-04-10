using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHelper : MonoBehaviour
{
   public GameObject button;

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
