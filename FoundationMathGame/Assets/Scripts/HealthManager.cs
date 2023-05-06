using UnityEngine;
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
        Debug.Log("I'm hit!");
        var damageAmount = target.GetComponent<HealthManager>();

        if (damageAmount != null)
        {
            damageAmount.TakeDamage(damaged);
            Debug.Log("I'm hitttttttttttttt!");
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

}
