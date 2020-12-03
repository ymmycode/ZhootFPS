using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] RigidbodyFirstPersonController FPController;
    [SerializeField] float zoomInFOV = 40f;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] [Range(0.1f, 2f)] float zoomInSensivity = 2f;
    [SerializeField] [Range(0.1f, 5f)] float zoomOutSensivity = 2f;
    
    bool holdToZoom = false;
    bool zoomInToggle = false;

    private void Update()
    {
        ZoomSetting(); // default is Toggle, press T again to change to Hold
        ZoomMode();
    }

    private void ZoomMode()
    {
        if (holdToZoom == true)
        {
            HoldZoom();
            Debug.LogWarning("Hold Mode");
        }
        else
        {
            ToggleZoom();
            Debug.LogWarning("Toggle Mode");
        }
    }

    private void ZoomSetting()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (holdToZoom == false)
            {
                holdToZoom = true; //Activating hold mode
            }
            else
            {
                holdToZoom = false; //Activating toggle mode
            }
        }
    }

    private void HoldZoom()
    {
        // hold to Zoom in and zoom out
        if (Input.GetMouseButtonDown(1))
        {
            ZoomIn();
        }

        if (Input.GetMouseButtonUp(1))
        {
            ZoomOut();
        }
    }private void ToggleZoom()
    {
        // hold to Zoom in and zoom out
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomInToggle == false)
            {
                zoomInToggle = true;
                ZoomIn();
            }
            else
            {
                zoomInToggle = false;
                ZoomOut();
            }
        }
    }

    public void SetToggleToZoom()
    {
        holdToZoom = false;
    }
    public void SetHoldToZoom()
    {
        holdToZoom = true;
    }
    void ZoomOut()
    {
        FPCamera.fieldOfView = zoomOutFOV;
        FPController.mouseLook.XSensitivity = zoomOutSensivity;
        FPController.mouseLook.YSensitivity = zoomOutSensivity;
    }
    void ZoomIn()
    {
        FPCamera.fieldOfView = zoomInFOV;
        FPController.mouseLook.XSensitivity = zoomInSensivity;
        FPController.mouseLook.YSensitivity = zoomInSensivity;
    }
    private void OnDisable()
    {
        ZoomOut();
    }

}
