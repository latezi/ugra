using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material selectMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();

        //interactable.hoverEntered.AddListener(SetSelectMaterial);
        
        interactable.hoverEntered.AddListener(SetSelectMaterial);
        interactable.hoverExited.AddListener(SetOriginalMaterial);

        //interactable.onHoverEnter.AddListener(SetSelectMaterial);
        //interactable.onHoverExit.AddListener(SetOriginalMaterial);
    }

    private void OnDestroy()
    {

        interactable.hoverEntered.RemoveListener(SetSelectMaterial);
        interactable.hoverExited.RemoveListener(SetOriginalMaterial);

       /* interactable.onHoverEnter.RemoveListener(SetSelectMaterial);
        interactable.onHoverExit.RemoveListener(SetOriginalMaterial);*/
    }

    private void SetSelectMaterial(HoverEnterEventArgs arg0)
    {
        meshRenderer.material = selectMaterial;
    }

    private void SetOriginalMaterial(HoverExitEventArgs arg0)
    {
        meshRenderer.material = originalMaterial;
    }
}
