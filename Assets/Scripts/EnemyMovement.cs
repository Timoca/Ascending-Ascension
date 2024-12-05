using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] bool movingRight = false;
    [SerializeField] bool movingLeft = false;
    [SerializeField] bool hover = false;

    public float hoverDistance = 2f;
    public float movementSpeed = 2f;

    [SerializeField] GameObject borderCheck = default;

    private Vector2 startPosition;
    private float distanceInbetween;
    private bool isAtStartPosition;

    private int randomizer;
    
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;
        randomizer = Random.Range(1, 3);
        

        if (movingLeft == true)
        {
            transform.Rotate(new Vector2(0, 180));
        }
    }
    

    private void FixedUpdate()
    {
        CheckForBordersAndFlip();

        if (movingRight == true)
        {
            MoveRight();
        }
        if (movingLeft == true)
        {
            MoveLeft();
        }
        if (hover == true)
        {
            Hovering();
        }
    }

    private void CheckForBordersAndFlip()
    {
        if (borderCheck == null)
        {
            return;
        }
        else
        {
            if (movingLeft == true)
            {
                RaycastHit2D ray = Physics2D.Raycast(borderCheck.transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Border"));


                if (ray.collider != null)
                {
                    transform.Rotate(new Vector2(0, 180));
                    movementSpeed = -movementSpeed;
                }
            }
            else
            {
                RaycastHit2D ray = Physics2D.Raycast(borderCheck.transform.position, Vector2.right, 0.5f, LayerMask.GetMask("Border"));


                if (ray.collider != null)
                {
                    transform.Rotate(new Vector2(0, 180));
                    movementSpeed = -movementSpeed;
                }
            }
        }
    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(movementSpeed, 0f);
    }
    private void MoveLeft()
    {
        rb.velocity = new Vector2(-movementSpeed, 0f);
    }
    private void Hovering()
    {
        distanceInbetween = Vector2.Distance(startPosition, transform.position);

        if (distanceInbetween <= 0.5)
        {
            isAtStartPosition = true;
        }

        if(distanceInbetween >= hoverDistance)
        {
            isAtStartPosition = false;
        }
        if(randomizer == 1)
        {
            if (isAtStartPosition == true)
            {
                rb.MovePosition(transform.position + transform.right * movementSpeed);
            }

            if (isAtStartPosition == false)
            {
                rb.MovePosition(transform.position + -transform.right * movementSpeed);
            }
        }
        if(randomizer == 2)
        {
            if (isAtStartPosition == true)
            {
                rb.MovePosition(transform.position + -transform.right * movementSpeed);
            }

            if (isAtStartPosition == false)
            {
                rb.MovePosition(transform.position + transform.right * movementSpeed);
            }
        }
        
    }
}
