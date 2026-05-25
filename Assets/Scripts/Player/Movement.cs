using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0;

    // [SerializeField] private float _jumpForce = 0;

    // private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        // _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _movementSpeed * Time.deltaTime);
    }
}
