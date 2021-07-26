using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class kobursocket : XRSocketInteractor
{
    public bool v_sockete = false;
    pistolet pist = null;

    protected override void OnEnable()
    {
        selectEntered.AddListener(zaryazhen);
        selectExited.AddListener(razryazen);
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        selectEntered.RemoveListener(zaryazhen);
        selectExited.RemoveListener(razryazen);
        base.OnDisable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        v_sockete = false;
        pist = null;
    }

    private void zaryazhen(SelectEnterEventArgs arg0)
    {
        pist = arg0.interactable.GetComponent<pistolet>();
        v_sockete = true;
    }

    private void Update()
    {
        if (v_sockete)
        {
            if (pist.currentmagazine!= null && pist.currentmagazine.bullets < 100)
            {
                pist.currentmagazine.bullets += Time.deltaTime;               
                pist.seeterline(pist.currentmagazine.bullets);
            }           
        }
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && match(interactable);
    }
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && match(interactable);
    }
    private bool match(XRBaseInteractable interactable)
    {
        return interactable.CompareTag("pistol");
    }
}
