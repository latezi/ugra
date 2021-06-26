using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class granadesocket : XRSocketInteractor
{
   // public GameObject cheka;
    private bool exploretime = false;
    public const float timer = 8.0f;
    public float extimer = timer;
    public float maxDistance = 10f;
    public float grenade_damage = 10f;
    private Itarget[] targets1;

    protected override void OnEnable()
    {
        //Instantiate(cheka, transform.position, transform.rotation);
        selectEntered.AddListener(stop);
        selectExited.AddListener(readytoexplore);
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        selectExited.RemoveListener(readytoexplore);
        selectEntered.RemoveListener(stop);
        //Destroy(cheka);
        base.OnDisable();
    }   

    private void readytoexplore(SelectExitEventArgs arg0)
    {        
        exploretime = true;
        showInteractableHoverMeshes = true;
    }
    private void stop(SelectEnterEventArgs arg0)
    {
        Debug.Log("chekaaa");
        exploretime = false;
        extimer = timer;
        showInteractableHoverMeshes = false;
    }
    private void Update()
    {
        if (exploretime)
        {
            if (extimer <= 0)
            {
                Debug.Log("explore");
                targets1 = currentweapon.Targets.ToArray();
                foreach (var o in targets1)
                {
                    if (o!= null)
                    {
                        if (Vector3.Distance(transform.position, o.distance()) < maxDistance)
                        {
                            Debug.Log("ranen");
                            o.catchbullet(Vector3.Distance(transform.position, o.distance() * grenade_damage));
                        }
                    }                                    
                }
                Destroy(gameObject);
            }
            else
            {
                extimer -= Time.deltaTime;
            }
        }            
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
