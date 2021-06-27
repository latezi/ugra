using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class granadesocket : XRSocketInteractor
{
    public GameObject verh;

    protected override void OnEnable()
    {
        selectEntered.AddListener(stop);
        selectExited.AddListener(readytoexplore);
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        selectExited.RemoveListener(readytoexplore);
        selectEntered.RemoveListener(stop);
        base.OnDisable();
    }   

    private void readytoexplore(SelectExitEventArgs arg0)
    {
        verh.GetComponent<kromch>().exploretime = true;
        showInteractableHoverMeshes = true;
    }
    private void stop(SelectEnterEventArgs arg0)
    {
        Debug.Log("chekaaa");
        verh.GetComponent<kromch>().exploretime = false;
        verh.GetComponent<kromch>().extimer = verh.GetComponent<kromch>().timer;
        showInteractableHoverMeshes = false;
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
        return interactable.CompareTag("cheka");
    }
}
