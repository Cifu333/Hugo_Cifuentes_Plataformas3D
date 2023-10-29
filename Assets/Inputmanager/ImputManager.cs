using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;

    private PlayerControl playerInputs;

    private Vector2 leftAxisValue = Vector2.zero;
    private float timeSinceCrouchPressed = 0f;
    private float JumpTimer = 0;

    
    //private bool Jump = false;
    private bool a;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInputs = new PlayerControl();
            playerInputs.Character.Enable();
            playerInputs.Character.Jump.performed += JumpButtonPresed;
            playerInputs.Character.Movement.performed += LeftAxisUpdate;
            playerInputs.Character.Crouch.performed += CrouchButtonPresed;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        JumpTimer += Time.deltaTime;
        timeSinceCrouchPressed += Time.deltaTime;
        InputSystem.Update();
    }

    private void JumpButtonPresed(InputAction.CallbackContext context)
    {
     

        JumpTimer = 0f;
        Debug.Log("ESPACIO");
    }

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();



        //Debug.Log("Magnitude: " + leftAxisValue.magnitude);
        //Debug.Log("Normalize: " + leftAxisValue.normalized);
    }

    private void CrouchButtonPresed(InputAction.CallbackContext context)
    {
        timeSinceCrouchPressed = 0f;
        Debug.Log("agacha");
    }

    public Vector2 GetLeftAxisUpdate()
    {
        return leftAxisValue.normalized;
    }

    public bool GetLeftAxisPressed()
    {

        return leftAxisValue.x != 0 || leftAxisValue.y != 0;
    }

    public float GetJumpButonPresed()
    {

        return JumpTimer;
        
       
    }

    public float GetCrouchButonPresed()
    {
        return timeSinceCrouchPressed;
    }

}
