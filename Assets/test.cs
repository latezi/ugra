using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class test : MonoBehaviour
{
    private ActionBasedController controller;
    public UnityEvent testevent;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.selectAction.action.performed += Action_performed;        
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

    }
}
