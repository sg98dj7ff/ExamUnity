using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
    [Header("UI Панели")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private Text text;
    
    [Header("Настройки курсора")]
    [SerializeField] private bool hideCursorOnStart = true;

    [Header("Игрок")]
    [SerializeField] private GameObject _player;
    
    void Start()
    {
        if (hideCursorOnStart)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        GamePanel?.SetActive(true);
        gameOverPanel?.SetActive(false);
    }

    void OnEnable()
    {
        GameEvents.OnGameOver += ShowGameResultPanel;
    }

    void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameResultPanel;
    }

    void ShowGameResultPanel(String messaage)
    {
        if (gameOverPanel != null)
        {
            GamePanel?.SetActive(false);

            text.text = messaage;
            gameOverPanel.SetActive(true);
    
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            // Останавливаем игровой процесс
            Time.timeScale = 0f;
        }
    }

    public void RestartLevel()
    {
        if (_player != null)
        {
            Vector3 respawnVector =  _player.transform.position;
            respawnVector.y = 2;
            _player.transform.position = respawnVector;            
        }

        Time.timeScale = 1f;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
