using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class socketwithtagcheck : XRSocketInteractor
{
    public string targetTag = string.Empty;

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
        Debug.Log("ne v pistolete");
       // arg0.interactable.GetComponent<magazine>().triggersoff();
        arg0.interactor.GetComponentInParent<pistolet>().currentmagazine = null;
        arg0.interactor.GetComponentInParent<pistolet>().seeterline(0);
        arg0.interactor.GetComponentInParent<pistolet>().Ismagazineonplace = false;
    }

    private void zaryazhen(SelectEnterEventArgs arg0)
    {
        Debug.Log("v pistolete");
        //arg0.interactable.GetComponent<magazine>().triggerson();
        arg0.interactable.GetComponent<magazine>().tty = this;
        arg0.interactor.GetComponentInParent<pistolet>().currentmagazine = arg0.interactable.GetComponent<magazine>();
        arg0.interactor.GetComponentInParent<pistolet>().seeterline(arg0.interactor.GetComponentInParent<pistolet>().currentmagazine.bullets);
        arg0.interactor.GetComponentInParent<pistolet>().Ismagazineonplace = true;  
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && match(interactable) && interactable.GetComponent<magazine>().grabactive;
    }
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && match(interactable) && interactable.GetComponent<magazine>().grabactive;
    }
    private bool match(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }
}

