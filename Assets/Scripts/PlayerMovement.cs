using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeedUp = 2f;
    public float horizontalMovementSpeed = 4f;
    public float upSpeed = 2f;
    public float downSpeed = 2f;

    private float baseMovement;

    private float horizontalMovement;
    private float upMovementSpeed;
    private float downMovementSpeed;

    private bool unPause = false;

    [SerializeField] GameObject instructionsUI;
        
    Rigidbody2D rb;

    MainMenu mainMenu;

    EnemyMovement[] enemyMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = FindObjectsOfType<EnemyMovement>();
        mainMenu = FindObjectOfType<MainMenu>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerInput>().enabled = false;
        
    }
    void Start()
    {
        Invoke(nameof(MakeSpriteRendererAndControllsEnabled), 2f);

        foreach (var obj in enemyMovement)
        {
            obj.GetComponent<EnemyMovement>().enabled = false;
        }

        if (instructionsUI != null)
        {
            instructionsUI.SetActive(true);
        }
        
    }

    
    void FixedUpdate()
    {    
        if (unPause == true)
            {
                HideInstructions();
                
                rb.velocity = new Vector2(horizontalMovement * horizontalMovementSpeed, baseMovement);
                baseMovement = movementSpeedUp;


                if (upMovementSpeed == 1)
                {
                    baseMovement = movementSpeedUp + upSpeed;
                }

                if (downMovementSpeed == 1)
                {
                    baseMovement = movementSpeedUp - downSpeed;
                }

                foreach (var obj in enemyMovement)
                {
                    obj.GetComponent<EnemyMovement>().enabled = true;
                }
        }
                 
    }
        
            
    
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        unPause = true;
    }

    public void UpMovementSpeed(InputAction.CallbackContext context)
    {
        upMovementSpeed = context.ReadValue<float>();
        unPause = true;
    }
    public void DownMovementSpeed(InputAction.CallbackContext context)
    {
        downMovementSpeed = context.ReadValue<float>();
        unPause = true;
    }

    public void EnablePauseMenu()
    {
        mainMenu.PauseGame();
    }

    private void MakeSpriteRendererAndControllsEnabled()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<PlayerInput>().enabled = true;
    }

    private void HideInstructions()
    {
        if (instructionsUI != null)
        {
            instructionsUI.SetActive(false);
        }
    }
}
