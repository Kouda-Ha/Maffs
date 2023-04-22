using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int damaged;
    [SerializeField] private TMP_Text healthText;

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
