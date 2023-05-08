using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Health manager, wanted a basic health and damage situation where 
// answering a question incorrectly will harm the player, and touching the
// main enemy also harms the player.
public class HealthManager : MonoBehaviour
{
    public int health;
    public int damaged;
    [SerializeField] private TMP_Text healthText;

    public void Update()
    {   // Check if player is dead
        if(health <= 0)
        {
            // If player is dead, the scene 2 restarts,
            // which is the horror section to the game (MMU_Evil)
            SceneManager.LoadScene(2);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        // Display health on the screen
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
    // If you enter the colision box of the enemy, you lose hit points 1 at a time
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }
}
