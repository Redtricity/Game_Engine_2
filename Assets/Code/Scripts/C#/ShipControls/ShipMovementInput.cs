using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementInput : MonoBehaviour
{
    [SerializeField] private ShipInputManager.InputType _inputType = ShipInputManager.InputType.HumanDesktop;
    
    public IMovementControls MovementControls { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        MovementControls = ShipInputManager.GetInputControls(_inputType);
    }

    private void OnDestroy()
    {
        MovementControls = null;
    }
}
