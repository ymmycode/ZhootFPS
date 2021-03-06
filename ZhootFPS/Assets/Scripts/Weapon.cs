﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject ammoStatusPlaceHolder;
    [SerializeField] Image weaponIcon;
    int weaponMag;

    void Update()
    {
        ammoStatusPlaceHolder.SetActive(true);
        DisplayAmmo();
        if(Input.GetButton("Fire1"))
        {
            if (Time.time - lastFired > 1 / fireRate )
            {
                lastFired = Time.time;
                Shoot();
            }
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurentAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void Shoot()
    {
        weaponMag = ammoSlot.GetCurentAmmoAmount(ammoType);
        if(weaponMag != 0)
        {
            PlayMuzzleFlashVFX();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount(ammoType);
        }
        else
        {
            //play ui anim
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

    private void OnEnable()
    {
        ammoStatusPlaceHolder.SetActive(true);
        weaponIcon.color = new Color(255, 255, 255, 255);
    }

    private void OnDisable()
    {
        if(ammoStatusPlaceHolder == null) return;
        ammoStatusPlaceHolder.SetActive(false);
        weaponIcon.color = new Color(0, 0, 0, 255);
    }

    
}
