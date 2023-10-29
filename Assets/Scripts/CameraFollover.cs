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
        rotationX += Input.GetAxis("Mouse Y") * 5;
        rotationY += Input.GetAxis("Mouse X") * 5;
        rotationX = Mathf.Clamp(rotationX, -89, 89);


    }

    Vector3 tmpFinalPosition;

    private void LateUpdate()
    {
    

        //Debug.Log(target.transform.position + offset);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0f);
        Vector3 finalPosition = Vector3.Lerp(transform.position, target.transform.position + offset - transform.forward * targetDistance, cameraLerp * Time.deltaTime);
        //Vector3 finalPosition = (target.transform.position + offset - transform.forward * targetDistance);
        tmpFinalPosition = finalPosition;

        
        RaycastHit hit;

        if (Physics.Linecast(target.transform.position + offset, finalPosition, out hit))
        {
            finalPosition = hit.point;
            tmpFinalPosition = hit.point;
        }
        
        transform.position = finalPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.transform.position + offset, 0.5f);
        Gizmos.DrawLine(target.transform.position + offset, tmpFinalPosition);
    }
}
