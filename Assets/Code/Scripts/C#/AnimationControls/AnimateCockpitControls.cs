using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{
    //flight control transforms
    [SerializeField] 
    private Transform _joystick;
    
    [SerializeField]
    Vector3 _joystickRange = Vector3.zero;

    [SerializeField]
    List<Transform> _throttles;

    [SerializeField] 
    float _throttleRange = 35f;

    [SerializeField] 
    private ShipMovementInput _movementInput;

    private IMovementControls ControlInput => _movementInput.MovementControls;
    
    // Update is called once per frame
    void Update()
    {
        _joystick.localRotation = Quaternion.Euler(ControlInput.PitchAmount * _joystickRange.x, ControlInput.YawAmount *_joystickRange.y,ControlInput.RollAmount * _joystickRange.z);
        
        Vector3 throttleRotation = _throttles[0].localRotation.eulerAngles;
        throttleRotation.x = ControlInput.ThrustAmount * _throttleRange;
        foreach (Transform throttle in _throttles)
        {
            throttle.localRotation = Quaternion.Euler(throttleRotation);
        }
    }

    
}
