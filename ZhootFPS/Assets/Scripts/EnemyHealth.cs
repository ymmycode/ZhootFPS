using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); // broadcast message for setting isProvoked to true
        
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("dead");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
