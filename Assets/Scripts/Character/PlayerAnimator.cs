using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private Movement move;

    [SerializeField]
    private Animator animator;


 
    //comprobamos si los parametros de movimiento se estan ejecutando para hacer una a nimacion o otra dependiendo de que funcion este activa

    void Update()
    {

        animator.SetBool("moving", move.IsMoving());
        animator.SetInteger("jump1", move.Getcount());
        animator.SetBool("IsGrounded", move.GetGround());


    }
}
