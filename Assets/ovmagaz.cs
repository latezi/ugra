using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ovmagaz : XRGrabInteractable
{
    public avtagchecker tty;
    public bool grabactive = true;
    public int bullets = 60;
    public void perezar(avtomat a)
    {
        grabactive = false;
        tty.onSelectExit.Invoke(this);
    }
}

