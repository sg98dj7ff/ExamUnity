using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.OnGameOver?.Invoke($"You won, your score: {_scoreManager.GetScore()}");
        }
    }
}
