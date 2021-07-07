using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wallsocket : XRSocketInteractor
{
    public GameObject trgobject;
    public GameObject spawnobject1;
    XRBaseInteractable last;
    GameObject prelast;
    public bool a = true;
    bool b = true;

    protected override void Awake()
    {
        prelast = Instantiate(trgobject, transform.position, transform.rotation);
        selectExited.AddListener(razryazen);
        selectExited.AddListener(wheee);
        base.Awake();
    }

    private void wheee(SelectExitEventArgs arg0)
    {
        last = arg0.interactable;
    }

    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
        selectExited.RemoveListener(wheee);
        b = false;
        base.OnDisable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        if (b && spawnobject1.activeSelf && ((last!= null && last.enabled)))
        {
            Instantiate(trgobject, transform.position, transform.rotation);
        }    
    }
}
