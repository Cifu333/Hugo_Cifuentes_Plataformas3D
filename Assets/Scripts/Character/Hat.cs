using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField]
    private GameObject sombrero;

    [SerializeField] GameObject target;

    private float timer = 3f;

    private bool isCreate = false;

    void Update()
    {
        if (Input_Manager._INPUT_MANAGER.GetTrowHat() && isCreate !=true )
        {
   

            //Comprobamos si el sombrero ha sido lanzado si es true se coloca el sombreto en la posicion que le decimos
            //reiniciamos el temporizador cuando llegue a 0 el sombrero se descativa

           


            isCreate = true;
            sombrero.transform.position = target.transform.position;
            timer = 3f;
            Debug.Log("Lanzar sombrero");
        }

        
        if(isCreate)
        {
            sombrero.SetActive(true);
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                isCreate=false;
                sombrero.SetActive(false);
            }
        }
        //si no ha sido lanzado mantiene la posicion original
        else
        {
            sombrero.transform.position = target.transform.position;
        }



    }

}
