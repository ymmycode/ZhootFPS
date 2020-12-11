using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float playerHealth = 100f;
    [SerializeField] DamageFeedback damageFeedback;
    [SerializeField] HealthBar healthBar;

    private void Start()
    {
        healthBar.SetMaxHealth(playerHealth);
    }

    public void TakePlayerHealth(float damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        if (playerHealth <= 0)
        {
            GetComponent<DeathHandler>().ShowGameOverPanel();
            //stop control and show game over panel
        }
    }
}
