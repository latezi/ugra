using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class pistolet : MonoBehaviour, Iweapon
{    
    [SerializeField] XRGrabInteractable xgab;
    [SerializeField] Transform rayorig;
    [SerializeField] LayerMask lay;
    public magazine currentmagazine;

    public bool Ismagazineonplace = false;

    public AudioSource no;
    public AudioSource yes;

    public int pistol_damage = 8;

    LineRenderer lineRenderer;
    public GameObject line1;
    public GameObject line2;
    bool lineon = false;

    public void OnEnable()
    {
        xgab.activated.AddListener(strelba);
        lineRenderer = GetComponent<LineRenderer>();
        xgab.selectEntered.AddListener(fdgasdfg);
        xgab.selectExited.AddListener(sfkdfk);
        lineRenderer.enabled = false;
    }

    public void OnDisable()
    {
        xgab.activated.RemoveListener(strelba);
        xgab.selectEntered.RemoveListener(fdgasdfg);
        xgab.selectExited.RemoveListener(sfkdfk);
    }

    private void sfkdfk(SelectExitEventArgs arg0)
    {
        lineRenderer.enabled = false;
        lineon = false;
    }

    private void fdgasdfg(SelectEnterEventArgs arg0)
    {
        lineon = true;
        lineRenderer.enabled = true;
    }


    private void strelba(ActivateEventArgs arg0)
    {
        fire();
    }

    void Update()
    {
        if (lineon)
        {
            lineRenderer.SetPosition(0, line1.transform.position);
            lineRenderer.SetPosition(1, line2.transform.position);
        }

    }


    public void fire()
    {
        if (currentmagazine != null && Ismagazineonplace)
        {
            weaponsoundShot();
            RaycastHit hit;
            if (Physics.Raycast(rayorig.position, rayorig.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lay))
            {
                if (hit.transform.GetComponent<Itarget>() != null)
                {
                    if (hit.transform.GetComponent<targetcube>() != null)
                    {
                        hit.transform.GetComponent<targetcube>().catchbullet(pistol_damage);
                        Debug.Log(hit.transform.GetComponent<targetcube>().hps);
                    }
                }
            }
            currentmagazine.bullets--;
            if (currentmagazine.bullets == 0)
            {
                currentmagazine.perezar(this);
            }
        }
        else
        {
            weaponsoundReload();
        }
    }

    public void weapanimation()
    {
        
    }

    public void weaponsoundShot()
    {
        yes.Play();
    }

    public void weaponsoundReload()
    {
        no.Play();
    }
}
