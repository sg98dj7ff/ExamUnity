using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _movementSpeed = 0;
    [SerializeField] private float _maxMovementSpeed = 0;
    [SerializeField] private float _movementAcceleration = 0;

    // [SerializeField] private float _jumpForce = 0;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _movementSpeed = _movementSpeed >= _maxMovementSpeed ? _maxMovementSpeed : _movementSpeed + _movementAcceleration * Time.deltaTime;

        transform.position = move * _movementSpeed * Time.deltaTime;
    }
}
