using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // Центр окружности (игрок)
    public float cameraRange = 5f; // Радиус окружности (R)
    public float mouseSensitivity = 100f;
    
    private float currentAngle = 0f; // Текущий угол в радианах
    
    void Start()
    {
        // Изначально камера за спиной игрока
        currentAngle = 0f;
        UpdateCameraPosition();
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        // Получаем движение мыши (длина дуги L)
        float mouseX = Input.GetAxis("Mouse X");
        
        if (mouseX != 0)
        {
            // Длина дуги = скорость мыши * чувствительность * время
            float arcLength = mouseX * mouseSensitivity * Time.deltaTime;
            
            // Угол в радианах = длина дуги / радиус
            float deltaAngle = arcLength / cameraRange;
            
            // Накопливаем угол
            currentAngle += deltaAngle;
            
            // Обновляем позицию камеры по окружности
            UpdateCameraPosition();
        }
    }
    
    void UpdateCameraPosition()
    {
        // Вычисляем позицию на окружности в плоскости XZ
        float x = Mathf.Sin(currentAngle) * cameraRange;
        float z = Mathf.Cos(currentAngle) * cameraRange;
        
        // Позиция камеры = центр (игрок) + смещение по окружности
        // Y координату оставляем как есть (например, камера на высоте 2 метра)
        Vector3 newPosition = player.position + new Vector3(x, 2f, z);
        
        transform.position = newPosition;
        
        // Камера всегда смотрит на игрока
        transform.LookAt(player.position + Vector3.up * 1.3f);
    }
}