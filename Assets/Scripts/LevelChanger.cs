using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] GameObject sucessMessage;
    [SerializeField] AudioSource victorySound;
    private void Awake()
    {
        sucessMessage.SetActive(false);
    }
    private void Start()
    {
        Cursor.visible = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            victorySound.Play();
            sucessMessage.SetActive(true);
            Invoke("ChangeToNextLevel", 3f);
        }
    }
    private void ChangeToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
