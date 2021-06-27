using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class firsttartgets : XRSocketInteractor
{
    public GameObject trgobject;
    //private List<GameObject> spawned1 = new List<GameObject>();
    private GameObject lastobject;
    protected override void OnEnable()
    {
        lastobject = Instantiate(trgobject, transform.position, transform.rotation);
        lastobject.GetComponent<targetcube>().gde = this;
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        Destroy(lastobject);
        base.OnDisable();
    }
    public void newcube()
    {
        Debug.Log("spawned");
        lastobject = Instantiate(trgobject, transform.position, transform.rotation);
        lastobject.GetComponent<targetcube>().gde = this;
    }
}