using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private Transform _cameraTransform; // Перетащите камеру сюда

    void Update()
    {
        // Получаем ввод
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        // Получаем направления камеры
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;
        
        // Убираем наклон по вертикали (чтобы не лететь вверх/вниз)
        forward.y = 0;
        right.y = 0;
        
        // Нормализуем, чтобы диагональное движение не было быстрее
        forward.Normalize();
        right.Normalize();
        
        // Вычисляем направление движения относительно камеры
        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;
        
        // Двигаем персонажа
        transform.Translate(moveDirection * _movementSpeed * Time.deltaTime, Space.World);

        if (transform.position.y < -10)
        {
            GameEvents.OnGameOver?.Invoke("you fell off the platform");
        }
    }
}