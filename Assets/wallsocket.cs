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
        base.Awake();
    }
    protected override void OnEnable()
    {
        spawned.Add(Instantiate(trgobject, transform.position, transform.rotation).gameObject);
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
        base.OnDisable();
    }
    protected override void OnDestroy()
    {
        foreach (var o in spawned)
        {
           Destroy(o.gameObject);
        }
        base.OnDestroy();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
         spawned.Add(Instantiate(trgobject, transform.position, transform.rotation).gameObject);
    }
}
