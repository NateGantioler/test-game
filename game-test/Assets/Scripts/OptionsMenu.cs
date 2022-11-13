using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;

    void Awake()
    {
        if(!PlayerPrefs.HasKey("soundVolume"))
        { 
            PlayerPrefs.SetFloat("soundVolume", 0.5f);
            Load();
        }
        else
        { 
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        Safe();
    }

    public void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void Safe()
    {
        PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
    }
}
