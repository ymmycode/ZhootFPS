using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject aboutText;
    [SerializeField] GameObject menuButtons;
    private void Start()
    {
        DisableAbout();
    }

    public void SetActiveAbout()
    {
        aboutText.SetActive(true);
        DisableMenuButtons();
    }

    public void SetActiveMenuButtons()
    {
        menuButtons.SetActive(true);
        DisableAbout();
    }

    public void DisableAbout()
    {
        aboutText.SetActive(false);
    }

    public void DisableMenuButtons()
    {
        menuButtons.SetActive(false);
    }

    public void PlayFirstStage()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
