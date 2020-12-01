using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); // broadcast message for setting isProvoked to true
        
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
