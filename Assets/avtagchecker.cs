using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class avtagchecker : XRSocketInteractor
{
    public string targetuTag = string.Empty;

    protected override void OnEnable()
    {
        this.selectEntered.AddListener(zaryazhen);
        this.selectExited.AddListener(razryazen);
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        this.selectEntered.RemoveListener(zaryazhen);
        this.selectExited.RemoveListener(razryazen);
        base.OnDisable();
    }
    private void razryazen(SelectExitEventArgs arg0)
    {
        Debug.Log("ne v avtomate");
        arg0.interactor.GetComponentInParent<avtomat>().currentmagazineav = null;
        arg0.interactor.GetComponentInParent<avtomat>().Ismagazineonplaceav = false;
    }

    private void zaryazhen(SelectEnterEventArgs arg0)
    {
        Debug.Log("v avtomate");
        arg0.interactable.GetComponent<ovmagaz>().tty = this;
        arg0.interactor.GetComponentInParent<avtomat>().currentmagazineav = arg0.interactable.GetComponent<ovmagaz>();
        arg0.interactor.GetComponentInParent<avtomat>().Ismagazineonplaceav = true;
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && match(interactable) && interactable.GetComponent<ovmagaz>().grabactive;
    }
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && match(interactable) && interactable.GetComponent<ovmagaz>().grabactive;
    }
    private bool match(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetuTag);
    }
}
