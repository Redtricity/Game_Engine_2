using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTargetMover : MonoBehaviour
{
    [SerializeField] float _radius = 2000f;
        [SerializeField] int _delay = 10;
    
        void OnEnable()
        {
            InvokeRepeating(nameof(MoveToRandomLocation), 0, _delay);
        }
    
        void  MoveToRandomLocation()
        {
            transform.position = Random.insideUnitSphere * _radius;
        }
}
