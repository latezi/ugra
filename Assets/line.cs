using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class line : XRGrabInteractable
{
    LineRenderer lineRenderer;
    public GameObject b1;
    bool a = false;

    protected override void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        selectEntered.AddListener(fdgasdfg);
        selectExited.AddListener(sfkdfk);
        base.Awake();
    }

    protected override void OnDisable()
    {
        selectEntered.RemoveListener(fdgasdfg);
        selectExited.RemoveListener(sfkdfk);
        base.OnDisable();
    }
    private void sfkdfk(SelectExitEventArgs arg0)
    {
        lineRenderer.enabled = false;
        a = false;
    }

    private void fdgasdfg(SelectEnterEventArgs arg0)
    {
        a = true;
        lineRenderer.enabled = true;
    }

    void Update()
    {
        if (a)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, b1.transform.position);
        }
        
    }
}
