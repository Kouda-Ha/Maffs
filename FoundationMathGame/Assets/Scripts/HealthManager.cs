using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int damaged;
    [SerializeField] private TMP_Text healthText;

    public void Update()
    {
        if(health <= 0)
        {
//            GetComponent<GrabCamera>().ReleaseCamera();
            SceneManager.LoadScene(2);
        }
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        healthText.SetText("Health: " + health + "%");
    }

    public void DealDamage(GameObject target)
    {
        var damageAmount = target.GetComponent<HealthManager>();

        if (damageAmount != null)
        {
            damageAmount.TakeDamage(damaged);
        }
    }
}
