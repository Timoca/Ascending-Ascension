using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAttackSound : MonoBehaviour
{
    [SerializeField] AudioSource attackSound;

    public void PrintEvent()
    {
        attackSound.Play();
    }
}
