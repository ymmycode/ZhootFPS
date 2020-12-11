using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float damage = 30f;


    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakePlayerHealth(damage);
        target.GetComponent<DamageFeedback>().ShowBloodHit();
    }
}
