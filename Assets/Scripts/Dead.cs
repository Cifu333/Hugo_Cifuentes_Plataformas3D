using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("SampleScene");

            Debug.Log("Game Over");
        }
    }

}
