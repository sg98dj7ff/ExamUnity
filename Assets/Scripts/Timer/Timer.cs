using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime = 60f;
    [SerializeField] private Text textComponent; // или TextMeshProUGUI
    
    private Coroutine timerCoroutine;
    private bool isRunning = false;
    
    public System.Action OnTimerEnd;

    // public void Start()
    // {
    //     textComponent = GetComponent<Text>();
    // }
    
    public void StartTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        
        timerCoroutine = StartCoroutine(TimerRoutine(startTime));
    }
    
    public void StopTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        isRunning = false;
    }
    
    private IEnumerator TimerRoutine(float remainingTime)
    {
        isRunning = true;
        
        while (remainingTime > 0 && isRunning)
        {
            // Обновляем UI
            UpdateDisplay(remainingTime);
            
            // Ждём 0.1 секунды (или 1 секунду — зависит от нужной частоты)
            yield return new WaitForSeconds(0.1f);
            
            // Уменьшаем время
            remainingTime -= 0.1f;
        }
        
        if (isRunning && remainingTime <= 0)
        {
            UpdateDisplay(0);
            OnTimerEnd?.Invoke();
        }
        
        isRunning = false;
    }
    
    private void UpdateDisplay(float time)
    {
        if (textComponent == null) return;
        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        textComponent.text = $"{minutes:00}:{seconds:00}";
    }
}