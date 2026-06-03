using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    
    private int currentScore;
    
    public int GetScore()
    {
        return currentScore;
    }

    private void OnEnable()
    {
        GameEvents.OnScoreChanged += HandleScoreChanged;
    }
    
    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= HandleScoreChanged;
    }

    private void HandleScoreChanged(int newScore)
    {
        currentScore += newScore;
        scoreText.text = $"Score: {currentScore}";
    }
}