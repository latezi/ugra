using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wallsocket : XRSocketInteractor
{
    public GameObject trgobject;
    public GameObject spawnobject1;
    public bool a = true;

    protected override void Awake()
    {
        Instantiate(trgobject, transform.position, transform.rotation, spawnobject1.transform);
        selectExited.AddListener(razryazen);
        base.Awake();
    }
    /*void Update()
    {
        if (a)
        {
            Instantiate(trgobject, transform.position, transform.rotation, spawnobject1.transform);
            a = false;
        }
    }*/
    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
        base.OnDisable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        if (spawnobject1.activeSelf)
        {
            Instantiate(trgobject, transform.position, transform.rotation, spawnobject1.transform);
        }     
    }
}
