using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private UiScene dead;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Destroy(player);

            Debug.Log("Game Over");
        }
    }

}
