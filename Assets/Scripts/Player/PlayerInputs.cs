using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerInputs : MonoBehaviour
{
    private PlayerActionAsset _playerActionAsset;

    public Action<Vector2> onPlayerMove;
    
    private void Awake()
    {
        _playerActionAsset = new PlayerActionAsset();
    }

    private void OnEnable()
    {
        _playerActionAsset.PlayerInputsMap.Enable();
        _playerActionAsset.PlayerInputsMap.PlayerMovement.canceled += OnInputCancelled;
    }

    private void OnDisable()
    {
        _playerActionAsset.PlayerInputsMap.Disable();
        _playerActionAsset.PlayerInputsMap.PlayerMovement.canceled -= OnInputCancelled;
    }
    
    private void Update()
    {
        
        if (_playerActionAsset.PlayerInputsMap.PlayerMovement.IsPressed())
        {
            onPlayerMove?.Invoke(_playerActionAsset.PlayerInputsMap.PlayerMovement.ReadValue<Vector2>());
        }
    }
    private void OnInputCancelled(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>());
        onPlayerMove?.Invoke(Vector2.zero);
    }

    
}
