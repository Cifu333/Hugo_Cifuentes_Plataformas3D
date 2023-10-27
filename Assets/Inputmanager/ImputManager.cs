using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;

    private PlayerControl playerInputs;

    private float timeSinceJumpPressed = 0f;
    private float timeSinceThrowPressed = 0f;
    //private float timeSinceCrouchPressed = 0f;
    private bool isCoruchPressed = false;
    private float timeSincePausePressed = 0f;


    private Vector2 leftAxisValue = Vector2.zero;
    private Vector2 rightAxisValue = Vector2.zero;




    private void Awake()
    {
        //Compruebo existencia de instancias al input manager

        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //Genero instancia y activo character scheme
            playerInputs = new PlayerControl();
            playerInputs.Character.Enable();

            //Delegates
            playerInputs.Character.Jump.performed += JumpButtonPressed;
            playerInputs.Character.Movement.performed += leftAxisUpdate;
            playerInputs.Character.Camera.performed += rightAxisUpdate;
            playerInputs.Character.Hat.performed += throwButtonPressed;
            playerInputs.Character.Crouch.performed += crouchButtonPressed;
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }



    }

    private void Update()
    {
        timeSinceJumpPressed += Time.deltaTime;
        //timeSinceCrouchPressed += Time.deltaTime;

        timeSincePausePressed += Time.deltaTime;
        timeSinceThrowPressed += Time.deltaTime;
        InputSystem.Update();

        //Debug.Log(GetSouthButtonPressed());

    }

    private void JumpButtonPressed(InputAction.CallbackContext context)
    {

        //Debug.Log("jump");

        timeSinceJumpPressed = 0;
    }
    private void leftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();

        Debug.Log("Magnitude: " + leftAxisValue.magnitude);
        Debug.Log("Normalized: " + leftAxisValue.normalized);



    }
    private void rightAxisUpdate(InputAction.CallbackContext context)
    {
        rightAxisValue = context.ReadValue<Vector2>();

        //Debug.Log("Magnitude: " + rightAxisValue.magnitude);
        //Debug.Log("Normalized: " + rightAxisValue.normalized);

    }
    private void throwButtonPressed(InputAction.CallbackContext context)
    {
        //Debug.Log("throw");
        timeSinceThrowPressed = 0;
    }
    private void crouchButtonPressed(InputAction.CallbackContext context)
    {
        //Debug.Log("crouch");
        //timeSinceCrouchPressed = 0;
        isCoruchPressed = !isCoruchPressed;

    }
    private void pauseButtonPressed(InputAction.CallbackContext context)
    {
        //Debug.Log("pause");
        timeSincePausePressed = 0;
    }
    public bool GetSouthButtonPressed()
    {
        return this.timeSinceJumpPressed == 0;
    }
    public bool GetNorthButtonPressed()
    {
        return this.timeSinceThrowPressed == 0;
    }
    public bool GetLeftTriggerPressed()
    {
        return this.isCoruchPressed;
    }
    public bool GetStartButtonPressed()
    {
        return this.timeSincePausePressed == 0;
    }
    public Vector2 GetLeftAxisValue()
    {
        return this.leftAxisValue;
    }
    public Vector2 GetRightAxisValue()
    {
        return this.rightAxisValue;
    }

}
