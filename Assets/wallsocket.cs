using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wallsocket : XRSocketInteractor
{
    public GameObject trgobject;
    private List<GameObject> spawned = new List<GameObject>();
    protected override void OnEnable()
    {
        spawned.Add(Instantiate(trgobject, transform.position, transform.rotation));
        selectExited.AddListener(razryazen);
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        selectExited.RemoveListener(razryazen);
        foreach (var o in spawned)
        {
            if (o != null)
            {
                Destroy(o);
            }
            
        }
        base.OnDisable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        spawned.Add(Instantiate(trgobject, transform.position, transform.rotation));
    }
}
