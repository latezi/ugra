using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class magazine : XRGrabInteractable
{
    public socketwithtagcheck tty;
    public float bullets = 100;

    public bool grabactive = true;

    protected override void Awake()
    {       
        base.Awake();
    }

    public void perezar(pistolet a)
    {
        tty.onSelectExited.Invoke(this.GetComponent<XRGrabInteractable>());
    }
}
