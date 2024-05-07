using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cameraMinY,_cameraMaxY,_cameraMinZ,_cameraMaxZ;
    [SerializeField] private Camera _camera;
    [SerializeField] private  float _zoomLevel;
    private bool _hasCancelled =true;
    private NewControls _input;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void OnEnable()
    {
        _input = new NewControls();
        _input.Player.Enable();
        _input.Player.CamerMovement.canceled += CamerMovement_canceled;
        _input.Player.CamerMovement.performed += CamerMovement_performed;
    }

    private void OnDisable()
    {
        _input.Player.CamerMovement.canceled -= CamerMovement_canceled;
        _input.Player.CamerMovement.performed -= CamerMovement_performed;
    }
    private void CamerMovement_performed(InputAction.CallbackContext obj)
    {
        _hasCancelled = false;    
    }

    private void CamerMovement_canceled(InputAction.CallbackContext obj)
    {
        _hasCancelled = true;
        _speed = 1;       
    }

    private void CalculateMovement()
    {
        var move = _input.Player.CamerMovement.ReadValue<Vector2>();
        _speed += 0.1f;

        var pos = transform.position;
        pos.y = Mathf.Clamp(transform.position.y, _cameraMinY, _cameraMaxY);
        pos.z = Mathf.Clamp(transform.position.z, _cameraMinZ, _cameraMaxZ);
        pos.x = Mathf.Clamp(transform.position.x,-64 ,-21 );
        transform.position = pos;
        transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime * _speed);    
    }
    // Update is called once per frame
    void Update()
    {
           if (_hasCancelled==false)
            {
                CalculateMovement();
            }
          
           if (_camera.fieldOfView>110)
        {
            _camera.fieldOfView = 110;
        }
           else if (_camera.fieldOfView<20)
        {
            _camera.fieldOfView = 20;
        }
       _camera.fieldOfView += _input.Player.ScrollWheel.ReadValue<float>();     
}
}
