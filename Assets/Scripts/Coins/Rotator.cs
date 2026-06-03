using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 130f; // градусов в секунду
    [SerializeField] private Vector3 axis = Vector3.right; // ось вращения (X, Y или Z)
    
    void Update()
    {
        transform.Rotate(axis * rotationSpeed * Time.deltaTime);
    }
}
