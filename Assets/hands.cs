using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hands : XRDirectInteractor
{
    public override bool CanHover(XRBaseInteractable interactable)
    {
        if (interactable.GetComponent<HandButton>() != null)
        {
            return true;
        }
        else return false;
    }
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return false;
    }
}
