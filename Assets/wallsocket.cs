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
        spawned.Add(Instantiate(trgobject, transform.position, transform.rotation).gameObject);
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
        foreach (var o in spawned)
        {
            Destroy(o);
        }
        //base.OnDisable();
    }
    protected override void OnDestroy()
    {      
        base.OnDestroy();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        spawned.Add(Instantiate(trgobject, transform.position, transform.rotation).gameObject);
    }
}
