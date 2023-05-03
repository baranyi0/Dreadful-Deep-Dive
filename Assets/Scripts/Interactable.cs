using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] InteractableObjectController controller;

    private void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        controller = GameObject.FindGameObjectWithTag("Scene").GetComponent<InteractableObjectController>();
    }

    private void Update()
    {
        _renderer.material.SetColor("_Emission", controller.color);
        _renderer.material.SetColor("_SpecColor", controller.color);
    }
}
