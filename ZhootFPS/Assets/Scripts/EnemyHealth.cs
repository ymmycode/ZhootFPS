using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        this.transform.GetComponent<EnemyAI>().isProvoked = true;
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
        print(hitPoints);
    }
}
