using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public HealthManager playerHealth;
    public HealthManager WrongAnswerDamage;
    public int health;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            WrongAnswerDamage.DealDamage(playerHealth.gameObject);
        }
    }

}
