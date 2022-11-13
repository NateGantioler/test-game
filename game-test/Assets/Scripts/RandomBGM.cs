using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomBGM : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundTrack;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomAudio();
    }

    private void PlayRandomAudio()
    {
        audioSource.clip = soundTrack[Random.Range(0, soundTrack.Length)];
        audioSource.Play();
        Invoke("PlayRandomAudio", audioSource.clip.length + 5);
    }
}
