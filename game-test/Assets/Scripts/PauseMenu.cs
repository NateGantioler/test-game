using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;

    void Update()
    {   
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }   

    private void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
