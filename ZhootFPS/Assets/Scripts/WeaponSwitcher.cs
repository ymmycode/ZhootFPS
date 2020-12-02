using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    void Start()
    {
        SetWeaponActive();
    }

        void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        ScrollWheelUp();
        ScrollWheelDown();
    }

    private void ScrollWheelDown()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0)
            //if at 0 reset to 2
            {
                currentWeapon = 2;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    private void ScrollWheelUp()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            //if greater thhan max (current is 2) reset to 0
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform) // weapons in weapon transform
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }


}
