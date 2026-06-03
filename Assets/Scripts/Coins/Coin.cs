using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // логика добавления счета и удаления монеты
            GameEvents.OnScoreChanged?.Invoke(value);
            Destroy(gameObject);
        }      
    }
}
