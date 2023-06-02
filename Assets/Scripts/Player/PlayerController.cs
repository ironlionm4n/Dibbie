using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private float rotationSpeed;

    private Rigidbody _playerRigidbody;
    private Vector3 _desiredDirection;
    private float _desiredRotation;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInputs.onPlayerMove += HandlePlayerMove;
    }
    
    private void OnDisable()
    {
        _playerInputs.onPlayerMove -= HandlePlayerMove;
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _desiredRotation);
        _playerRigidbody.velocity = transform.TransformDirection(_desiredDirection) * (moveSpeed * Time.deltaTime);
    }

    private void HandlePlayerMove(Vector2 inputDirection)
    {
        _desiredRotation = inputDirection.x * rotationSpeed * Time.deltaTime;
        _desiredDirection = new Vector3(0, _playerRigidbody.velocity.y, inputDirection.y);
    }
}
