using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Camera camera;

  //  declaramos las vatiables que necesitaremos y referenciamos a los componentes que usaremos

    private CharacterController controller;

    private Vector2 input;

    private bool Ismoving = false;

    private int count = 0;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float gravity = 1;

    private Vector3 finalVelocity = Vector3.zero;
    private float velocityXZ = 5f;

 
    private void Awake()
    {
        //bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
    }


    
    private void Update()
    {
        
       //obtenemos el input del jugador desde el inpur manager y comprobamos si esta presionando el boton de movimiento.

        input = Input_Manager._INPUT_MANAGER.GetLeftAxisUpdate();

        if (Input_Manager._INPUT_MANAGER.GetLeftAxisPressed())
        {
            Ismoving = true;
        }
        else
        {
            Ismoving = false;
        }

        //Debug.Log(Ismoving);

        // Calcula la dirección en el plano XZ basado en la orientación de la cámara
        // Ajusta la rotación del objeto para que siga la dirección de la cámara
        //normalizamos la dirccion para q no afecte a la velocidad

        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(input.x,0, input.y);
        transform.rotation = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f);
        direction.Normalize();

        direction.y = -1f;

        // calculamos la velocidad en el plano XZ
        finalVelocity.x = direction.x * velocityXZ;
        finalVelocity.z = direction.z * velocityXZ;


        //resseteamos el contador y la fuerza del salto despues de 3 saltos

        if (count == 3)
        {
            jumpForce = 5;
            count = 0;
        }

        //comprobamso que el jugador este en el suelo
        if (controller.isGrounded)

        {
            Debug.Log("ISGROUND");
           // si el el boton de salto ha sido pulsado hace que el jugador salte, aumenta la fuerza para el proximo salto y aumenta en 1 el contador de salto
            if (Input_Manager._INPUT_MANAGER.getJUmpButton())
            {
                Debug.Log("isjumping");
                finalVelocity.y = jumpForce;
                jumpForce += jumpForce;
                count++;
            }
          

        }

        //aplicamos gravedad y movemos al persoaje 
        finalVelocity.y += direction.y * gravity * Time.deltaTime;
        controller.Move(finalVelocity * Time.deltaTime);
       



    }
    //indicamos cuanto ha de saltar
    public Vector3 SetJump()
    {
        finalVelocity.y = 10;
        return finalVelocity;
    }
    //comprobamos si el jugados se esta moviendo
    public bool IsMoving()
    {
        return Ismoving;
    }

    //comprobamos el numero de salto que ha realizado el jugador
    public int Getcount()
    {
        return count;
    }
    //comprobamos si el jugador esta en el suelo
    public bool GetGround()
    {
        return controller.isGrounded;
    }

}
