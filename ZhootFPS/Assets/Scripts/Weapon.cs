using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 10;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] float fireRate = 10f;
    [SerializeField] float lastFired;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammoSlot; 
    int weaponMag;

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if (Time.time - lastFired > 1 / fireRate )
            {
                lastFired = Time.time;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        weaponMag = ammoSlot.GetCurentAmmoAmount();
        if(weaponMag != 0)
        {
            PlayMuzzleFlashVFX();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount();
        }
        else
        {
            Debug.LogWarning("Empty Mag");
        }
    }

    private void PlayMuzzleFlashVFX()
    {
        muzzleFlashVFX.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; } //if the target don't have "enemyhealth", return / do nothing
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if (hit.collider == true)
        {
            var hitImpact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitImpact, 0.5f);
        }
    }
}
