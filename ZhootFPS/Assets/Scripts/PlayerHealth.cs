using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float playerHealth = 100f;

    public void TakePlayerHealth(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            print("DED");
            GetComponent<DeathHandler>().ShowGameOverPanel();
            //stop control and show game over panel
        }
    }
}
