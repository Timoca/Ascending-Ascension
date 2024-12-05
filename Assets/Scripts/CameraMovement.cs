using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = new Vector3(0f, player.position.y + 2f, -10f);
    }
}
