using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    private CharacterController controller;

    private Vector3 finalVelocity = Vector3.zero;
    private float velocityXZ = 5f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        //Calcular direccion XZ
        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction.Normalize();

        //Calcular velocidad XZ
        finalVelocity.x = direction.x * velocityXZ;
        finalVelocity.z = direction.z * velocityXZ;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
