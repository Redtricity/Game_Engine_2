using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
    [SerializeField] private ShipMovementInput _movementInput;
    //Ship Movement Values
    [SerializeField] [Range(1000f, 10000f)]
    private float _thrustForce = 7500f,
        _pitchForce = 6000f,
        _rollForce = 1000f,
        _yawForce = 2000f;

    private Rigidbody _rigidBody;
    [Range(-1f, 1f)]
    public float _thrustAmount, _pitchAmount, _rollAmount, _yawAmount = 0f;

    private IMovementControls ControlInput => _movementInput.MovementControls;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _thrustAmount = ControlInput.ThrustAmount;
        _rollAmount = ControlInput.RollAmount;
        _yawAmount = ControlInput.YawAmount;
        _pitchAmount = ControlInput.PitchAmount;
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(0f, _pitchAmount)) //pitch
        {
            _rigidBody.AddTorque(transform.right * (_pitchForce * _pitchAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _rollAmount)) //roll
        {
            _rigidBody.AddTorque(transform.forward * (_rollForce * -_rollAmount * Time.fixedDeltaTime));
        }
        
        if (!Mathf.Approximately(0f, _yawAmount)) //yaw
        {
            _rigidBody.AddTorque(transform.up * (_yawForce * _yawAmount * Time.fixedDeltaTime));
        }
        
        if (!Mathf.Approximately(0f, _thrustAmount)) //thrust
        {
            _rigidBody.AddForce(transform.forward * (_thrustForce * _thrustAmount * Time.fixedDeltaTime));
        }
    }
}


