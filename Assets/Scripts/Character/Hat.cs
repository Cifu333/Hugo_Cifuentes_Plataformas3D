using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{

    void Update()
    {
        if (Input_Manager._INPUT_MANAGER.GetTrowHat())
        {
            Debug.Log("GGGGGGGGGGGGGGGGGGGG");
        }
    }
}
