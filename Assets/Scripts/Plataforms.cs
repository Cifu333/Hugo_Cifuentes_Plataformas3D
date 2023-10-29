using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforms : MonoBehaviour
{
    
    [SerializeField]
    private Movement move;


    private void OnTriggerEnter(Collider other)
    {
        move.SetJump();
    }
}
