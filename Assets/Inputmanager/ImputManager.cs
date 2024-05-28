using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;

    private PlayerControl playerInputs;

    private Vector2 leftAxisValue = Vector2.zero;
    private float timeSinceCrouchPressed = 0f;
    private float timeSinceJumpPressed = 0f;
    private float timeSinceHatLeft = 0f;
    private bool crouch = false;

    private bool jumpButtonPressed = false;
    private bool crouchButtonPressed = false;
    private bool hatleft = false;


    //private bool Jump = false;
    private bool a;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {//configurar inputs del jugador
            playerInputs = new PlayerControl();
            playerInputs.Character.Enable();
            playerInputs.Character.Jump.performed += JumpButtonPresed;
            playerInputs.Character.Movement.performed += LeftAxisUpdate;
            playerInputs.Character.Crouch.performed += CrouchButtonPresed;
            playerInputs.Character.Crouch.performed += CrouchButtonReleased;
            playerInputs.Character.Hat.performed += TrowHat;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        crouchButtonPressed = false;

        //actualizar el ultimo input de los botones
        timeSinceJumpPressed += Time.deltaTime;
        timeSinceCrouchPressed += Time.deltaTime;
        InputSystem.Update();
    }
    // mira si se ha pulsado el boton de salto mira los saltos restantes
    private void JumpButtonPresed(InputAction.CallbackContext context)
    {
        jumpButtonPressed = !jumpButtonPressed;

        timeSinceJumpPressed = 0f;
        Debug.Log("ESPACIO");
    }


    //mira si se ha lanzado el sombrero y avisa cuando se acaba al tiempo

    private void TrowHat(InputAction.CallbackContext context)
    {
        hatleft = !hatleft;

        timeSinceHatLeft = 0f;
        //Debug.Log("tiras sombrero");
    }

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();
        //Debug.Log("Magnitude: " + leftAxisValue.magnitude);
        //Debug.Log("Normalize: " + leftAxisValue.normalized);
    }

    //mira si se ha pulsaod el boton de agacharse
    private void CrouchButtonPresed(InputAction.CallbackContext context)
    {
        crouch = true;
        Debug.Log("agacha");
    }
    //mira si el boton de agacharse se ha dejado de pulsar
    private void CrouchButtonReleased(InputAction.CallbackContext context)
    {
        crouch = false;
        Debug.Log("se levanta");
    }



    public Vector2 GetLeftAxisUpdate()
    {
        return leftAxisValue.normalized;
    }

    public bool GetLeftAxisPressed()
    {

        return leftAxisValue.x != 0 || leftAxisValue.y != 0;
    }

    public bool getJUmpButton()
    {
        //Debug.Log("Pruebasalto");
        return jumpButtonPressed;
    }

    public float GetTimeJumpButton()
    {
        return timeSinceJumpPressed;  
;
    }


    public bool GetTrowHat()
    {
        return hatleft;
        
    }

    public float GetCrouchButonPresed()
    {
        return timeSinceCrouchPressed;
    }

}
