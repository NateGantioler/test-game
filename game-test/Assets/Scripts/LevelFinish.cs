using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("PlayNextLevel", 2);
        collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        collision.GetComponent<Animator>().SetTrigger("win");
        finishSound.Play();
    }

    private void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
