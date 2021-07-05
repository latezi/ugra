using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handcontroller : MonoBehaviour
{
    [SerializeField] InputActionReference grip;
    [SerializeField] InputActionReference activate;

    public bool a = true, b = true;
    private Animator dsfsd;

    private void Awake()
    {
        // grip.action.
        grip.action.canceled += dsfsda;
        grip.action.performed += gripp;
        activate.action.performed += accctive;
        activate.action.canceled += dsfgsdsrt;
        dsfsd = GetComponent<Animator>();
    }

    private void dsfgsdsrt(InputAction.CallbackContext obj)
    {
        dsfsd.SetFloat("Trigger", 0);
    }

    private void dsfsda(InputAction.CallbackContext obj)
    {
        dsfsd.SetFloat("Grip", 0);
    }

    private void gripp(InputAction.CallbackContext obj)
    {
        dsfsd.SetFloat("Grip", 1);     
    }

    private void accctive(InputAction.CallbackContext obj)
    {
        dsfsd.SetFloat("Trigger", 1);      
    }    
}
