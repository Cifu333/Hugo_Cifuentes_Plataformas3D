using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollover : MonoBehaviour
{
    private float rotationX = 0f;
    private float rotationY = 0f;
    [SerializeField] float targetDistance = 0f;
    [SerializeField] GameObject target;
    [SerializeField] float cameraLerp = 12f;

    [SerializeField]
    private Vector3 offset;

    private Vector3 FinaltargetPosition;

    private void Update()
    {
        //actualiza la rotacion de la camara y la limita 
        rotationX += Input.GetAxis("Mouse Y") * 5;
        rotationY += Input.GetAxis("Mouse X") * 5;
        rotationX = Mathf.Clamp(rotationX, -89, 89);


    }

    //posicion final de la camara
    Vector3 tmpFinalPosition;

    private void LateUpdate()
    {
   //calcular posicion final de la camara
        transform.eulerAngles = new Vector3(rotationX, rotationY, 0f);
        Vector3 finalPosition = Vector3.Lerp(transform.position, target.transform.position + offset - transform.forward * targetDistance, cameraLerp * Time.deltaTime);
        tmpFinalPosition = finalPosition;

        // Realiza un chequeo de colisión para evitar que la cámara atraviese objetos
        RaycastHit hit;

        if (Physics.Linecast(target.transform.position + offset, finalPosition, out hit))
        {
            finalPosition = hit.point;
            tmpFinalPosition = hit.point;
        }
        
        transform.position = finalPosition;
    }
    // Dibuja una esfera en la posición del objetivo más el desplazamiento de la cámara
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.transform.position + offset, 0.5f);
        Gizmos.DrawLine(target.transform.position + offset, tmpFinalPosition);
    }
}
