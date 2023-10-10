using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    [SerializeField] public Transform _target;
    // Start is called before the first frame update

    private void LateUpdate()
    {
        transform.rotation = _target.rotation;
    }
}
