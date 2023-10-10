using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SkyBoxSet : MonoBehaviour //creating main screen and skybox
{
    [SerializeField] private List<Material> _skyBoxMaterials;

    private Skybox _skyBox;

    private void Awake()
    {
        _skyBox = GetComponent<Skybox>();
    }

    private void OnEnable()
    {
        ChangeSkyBox(0);
    }

    private void ChangeSkyBox(int skyBox)
    {
        if (_skyBox != null  && skyBox >= 0 && skyBox<= _skyBoxMaterials.Count)
        {
            _skyBox.material = _skyBoxMaterials[skyBox];
        }
    }
}
