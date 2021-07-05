using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previvousPress = false;

    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hoveriteractor = null;

    protected override void Awake()
    {

        base.Awake();
        hoverEntered.AddListener(Startpress);

        //onHoverEnter.AddListener(Startpress);
        hoverExited.AddListener(Findpress);
        //onHoverExit.AddListener(Findpress);
    }

    private new void OnDestroy()
    {
        hoverEntered.RemoveListener(Startpress);
        hoverExited.RemoveListener(Findpress);
        //onHoverEnter.RemoveListener(Startpress);
        // onHoverExit.RemoveListener(Findpress);
    }

    private void Startpress(HoverEnterEventArgs arg0)
    {
        hoveriteractor = arg0.interactor;
        previousHandHeight = GetLocalYPosition(hoveriteractor.transform.position);
    }

    private void Findpress(HoverExitEventArgs arg0)
    {
        hoveriteractor = null;
        previousHandHeight = 0.0f;

        previvousPress = false;
        SetYPosition(yMax);
    }
    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoveriteractor)
        {
            float newHandHeight = GetLocalYPosition(hoveriteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localposition = transform.root.InverseTransformPoint(position);
        return localposition.y;
    }

    private void SetYPosition(float pos)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(pos, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previvousPress)
        {
            //Debug.Log("press");
            OnPress.Invoke();
            if(tag == "gren")
            {
                currentweapon.vklucheniekubov();
            }
        }         

        previvousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);
        return transform.localPosition.y == inRange;
    }
}
