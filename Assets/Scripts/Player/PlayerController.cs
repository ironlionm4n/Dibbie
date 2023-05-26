using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerInputs _playerInputs;

    private Rigidbody _playerRigidbody;
    private Vector3 _desiredDirection;

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
        _playerRigidbody.velocity = _desiredDirection * (moveSpeed * Time.deltaTime);
    }

    private void HandlePlayerMove(Vector2 inputDirection)
    {
        _desiredDirection = new Vector3(inputDirection.x, _playerRigidbody.velocity.y, inputDirection.y);
    }
}
