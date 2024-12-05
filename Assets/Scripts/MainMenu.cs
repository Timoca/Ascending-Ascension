using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    private GameObject mainMenuObject;
    private GameObject creditsObject;
    private GameObject pauseMenuObject;


    private Canvas mainMenu;
    private Canvas credits;
    private Canvas pauseMenu;
    private void Awake()
    {
        mainMenuObject = GameObject.Find("Canvas Main Menu");
        if(mainMenuObject != null)
        {
            mainMenu = mainMenuObject.GetComponent<Canvas>();
        }

        creditsObject = GameObject.Find("Canvas Credits");
        if(creditsObject != null)
        {
            credits = creditsObject.GetComponent<Canvas>();
        }

        pauseMenuObject = GameObject.Find("Pause Menu Canvas");
        if(pauseMenuObject != null)
        {
            pauseMenu = pauseMenuObject.GetComponent<Canvas>();
        }
        

        if(mainMenu != null && credits != null)
        {
            mainMenu.enabled = true;
            credits.enabled = false;
        }

        if(pauseMenu != null)
        {
            pauseMenu.enabled = false;
        }

        Cursor.visible = true;
    }

    public void StartLevelOne()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void Credits()
    {
        mainMenu.enabled = false;
        credits.enabled = true;
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1;
        credits.enabled = false;
        mainMenu.enabled = true;
    }

    public void ReturnMainMenuFromGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        pauseMenu.enabled = true;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseMenu.enabled = false;
    }

    public void UISound()
    {
        clickSound.Play();
    }
}
