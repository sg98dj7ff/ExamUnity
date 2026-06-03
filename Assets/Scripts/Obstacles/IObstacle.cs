using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // логика проигрыша
            Debug.Log("Obstacle hit the player!");
            GameEvents.OnGameOver?.Invoke("You died from an obstacle");
        }      
    }
}
