using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforms : MonoBehaviour
{
    
    [SerializeField]
    private Movement move;

    [SerializeField]
    private AudioClip audioClip;

    AudioSource boing;

    private void Awake()
    {
        boing = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        move.SetJump();
    }
}
