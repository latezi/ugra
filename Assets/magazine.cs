using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class magazine : XRGrabInteractable //monobehavior
{
    [SerializeField] XRGrabInteractable xgab;
    public socketwithtagcheck tty;
    public bool grabactive = true;
    public int bullets = 8;

    protected override void OnEnable()
    {
        //xgab.activated.AddListener(perezar); 
    }

    protected override void OnDisable()
    {
        //xgab.activated.RemoveListener(perezar);
    }
   
    public void perezar(pistolet a)
    {
        grabactive = false;
        tty.onSelectExit.Invoke(this);
    }
}
