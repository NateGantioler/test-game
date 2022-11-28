using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManagerScript : MonoBehaviour
{
    static public float TimeScale = 1f;
    [SerializeField] private float SlowDownScale = 0.5f;
    [SerializeField] private float SlowDownPitch = 0.85f;
    [SerializeField] private float SpeedUpScale = 2f;
    [SerializeField] private float SpeedUpPitch = 1.15f;
    [SerializeField] private TextMeshProUGUI TimeManagerText;
    private GameObject musicManager;
    private AudioSource musicSource;

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        musicSource = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            TimeManagerText.enabled = false;
        }
        else
        {
            TimeManagerText.enabled = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SlowDownTime();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            SpeedUpTime();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            FreezeTime();
        }
    }

    private void SlowDownTime()
    {
        if(TimeScale == SlowDownScale)
        {
            ResetTime();
        }
        else
        {
            TimeScale = SlowDownScale;
            musicSource.pitch = SlowDownPitch;
        }
        ChangeText(TimeScale);
    }

    private void SpeedUpTime()
    {
        if(TimeScale == SpeedUpScale)
        {
            ResetTime();
        }
        else
        {
            TimeScale = SpeedUpScale;
            musicSource.pitch = SpeedUpPitch;
        }
        ChangeText(TimeScale);
    }

    private void FreezeTime()
    {
        if(TimeScale == 0f)
        {
            ResetTime();
        }
        else
        {
            TimeScale = 0f;
            musicSource.pitch = 1f;
        }
        ChangeText(TimeScale);
    }

    private void ResetTime()
    {
        TimeScale = 1f;
        musicSource.pitch = 1f;
    }

    private void ChangeText(float TimeScale)
    {
        TimeManagerText.text = TimeScale + "x";
    }

}
