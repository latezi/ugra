using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class magazine : MonoBehaviour
{
    public socketwithtagcheck tty;
    public bool grabactive = true;
    public int bullets = 8;

    public void perezar(pistolet a)
    {
        grabactive = false;
        tty.onSelectExited.Invoke(this.GetComponent<XRGrabInteractable>());
    }
}
