using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //private Audio_Manager audioManager;

    private static int getCoins;

    [SerializeField]
    private AudioClip pickCoin;


    private void Start()
    {
        getCoins = 0;

        //audioManager = Audio_Manager._AUDIO_MANAGER;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            getCoins++;
            Debug.Log("Get Coin");
            //audioManager.ReproduceSound(pickCoin);

            Destroy(gameObject);
        }
        if(getCoins == 10)
        {
            Debug.Log("You Win");
        }
    }
}
