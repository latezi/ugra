using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class avmagazine : XRGrabInteractable
{
    [SerializeField] XRGrabInteractable xgab;
    public int bullets = 30;
    public void perezar()
    {
        Destroy(gameObject);
    }
}
