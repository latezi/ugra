using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wallsocket : XRSocketInteractor
{
    public GameObject trgobject;
    public GameObject spawnobject1;
    protected override void Awake()
    {
        selectExited.AddListener(razryazen);
        Instantiate(trgobject, transform.position, transform.rotation).transform.SetParent(spawnobject1.transform);     
        base.Awake();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
        base.OnDisable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        Instantiate(trgobject, transform.position, transform.rotation).transform.SetParent(spawnobject1.transform);
    }
}
