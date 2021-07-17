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
    public bool a = true;
    static bool b = true;

    protected override void Awake()
    {
        Instantiate(trgobject, transform.position, transform.rotation);
        selectExited.AddListener(razryazen);
       // selectExited.AddListener(wheee);
        base.Awake();
    }

    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
       // selectExited.RemoveListener(wheee);      
        base.OnDisable();
    }

    private void OnApplicationQuit()
    {
        b = false;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnEnable()
    {
        //b = true;
        showInteractableHoverMeshes = false;
        base.OnEnable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        if (b)
        {
            Instantiate(trgobject, transform.position, transform.rotation);
        }    
    }
}
