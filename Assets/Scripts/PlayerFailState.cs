using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFailState : MonoBehaviour
{
    [SerializeField] AudioSource failSound;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            failSound.Play();
            rb.gravityScale = 50;
            Invoke("RestartLevel", 2f);
        }
    }

    void RestartLevel()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }    
}
