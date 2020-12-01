using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    private void Start()
    {
        gameOverPanel.SetActive(false);
        UnpauseLockCursor();
    }
    
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        PauseUnlockCursor();
    }

    private static void PauseUnlockCursor()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private static void UnpauseLockCursor()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
