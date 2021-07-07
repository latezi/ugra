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
    public bool a = false;
    public float currenttimer = 3.0f;
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

    void Update()
    {
        if (a)
        {
            if (currenttimer<0)
            {
                a = false;
                lastobject = Instantiate(trgobject, transform.position, transform.rotation);
                lastobject.GetComponent<targetcube>().gde = this;
                currenttimer = 3.0f;
                Debug.Log("spawned");
            }
            else
            {
                currenttimer -= Time.deltaTime;
            }
        }
    }

    public void newcube()
    {     
        a = true;
    }
}
