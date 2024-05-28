using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //acedemos al audio manager
    private Audio_Manager audioManager;

    private static int getCoins;

   


  

    private void OnTriggerEnter(Collider other)
    {
        //si el jugador toca la moneda la coje y suma uno a su contador tambien hace sonar el audio de recojer moneda si recojes 10 ganas
        if (other.gameObject.CompareTag("Player"))
        {

            getCoins++;
            Debug.Log("Get Coin");
            audioManager = GetComponent<Audio_Manager>();
        

            Destroy(gameObject);
        }
        if(getCoins == 10)
        {
            Debug.Log("You Win");
        }
    }
}
