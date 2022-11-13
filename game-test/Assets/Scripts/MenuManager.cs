using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject infoText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject managers;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Info()
    {
        mainMenu.SetActive(false);
        infoText.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        infoText.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
        Destroy(managers);
        Time.timeScale = 1;
    }
}

