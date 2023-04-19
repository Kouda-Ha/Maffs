using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int damaged;

    public void TakeDamage(int amount)
    {
        health -= amount;
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
