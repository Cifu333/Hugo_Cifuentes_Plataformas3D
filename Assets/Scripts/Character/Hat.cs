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
           isCreate = true;
            sombrero.transform.position = target.transform.position;
            timer = 3f;
            Debug.Log("GGGGGGGGGGGGGGGGGGGG");
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
        else
        {
            sombrero.transform.position = target.transform.position;
        }



    }

}
