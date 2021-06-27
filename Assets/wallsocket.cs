using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wallsocket : XRSocketInteractor
{
    public GameObject trgobject;
    private List<GameObject> spawned = new List<GameObject>();

    protected override void Awake()
    {
        selectExited.AddListener(razryazen);
        selectEntered.AddListener(added);
        var a = Instantiate(trgobject, transform.position, transform.rotation);
        a.transform.parent = this.transform;
        base.Awake();
    }

    private void added(SelectEnterEventArgs arg0)
    {

    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
        selectEntered.RemoveListener(added);
        base.OnDisable();
    }
    protected override void OnDestroy()
    {      
        base.OnDestroy();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        var a = Instantiate(trgobject, transform.position, transform.rotation);
        a.transform.parent = this.transform;
    }
}
