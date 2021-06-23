using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class avtomat : MonoBehaviour, Iweapon
{
    [SerializeField] XRGrabInteractable xgab;
    [SerializeField] Transform rayorig;
    [SerializeField] LayerMask lay;
    public avmagazine currentmagazineav;

    public const float timer = 0.3f;
    public float curtimer = -0.1f;

    public bool Ismagazineonplaceav = true, firetime = false;

    public int avtom_damage = 1;

    private void OnEnable()
    {
        xgab.activated.AddListener(strelba11);
        xgab.deactivated.AddListener(stroppp);
    }

    private void OnDisable()
    {
        xgab.activated.RemoveListener(strelba11);
        xgab.deactivated.RemoveListener(stroppp);
    }

    private void strelba11(ActivateEventArgs arg0)
    {
        firetime = true;
        currentweapon.Currentweapon_2 = this;
    }

    private void stroppp(DeactivateEventArgs arg0)
    {
        firetime = false;
    }

    public void settermag(XRBaseInteractable interactable)
    {
        this.currentmagazineav = interactable.GetComponent<avmagazine>();
    }

    public void setter(bool p)
    {
        this.Ismagazineonplaceav = p;
    }

    void Update()
    {
        if (firetime)
        {
            if (curtimer < 0)
            {
                fire();
                curtimer = timer;
            }
            else
            {
                curtimer -= Time.deltaTime;
            }
        }
        else
        {
            if (curtimer > 0)
            {
                curtimer -= Time.deltaTime;
            }
        }
    }

    public void fire()
    {
        if (Ismagazineonplaceav && currentmagazineav != null && currentmagazineav.bullets > 0)
        {
            weaponsoundShot();
            RaycastHit hit;
            if (Physics.Raycast(rayorig.position, rayorig.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lay))
            {
                if (hit.transform.GetComponent<Itarget>() != null)
                {
                    if (hit.transform.GetComponent<targetcube>() != null)
                    {
                        hit.transform.GetComponent<targetcube>().catchbullet(avtom_damage);
                        Debug.Log(hit.transform.GetComponent<targetcube>().hps);
                    }
                }
            }
        }
        else
        {
            if (currentmagazineav == null)
                Debug.LogWarning("not avtomat magazine");
            if (!Ismagazineonplaceav)
                Debug.LogWarning("not avtomat on place");
            if (currentmagazineav.bullets == 0)
            {
                //weaponsoundReload();
                Debug.LogWarning("avtomat havent patrons");
            }
        }
    }

    public void weapanimation()
    {

    }

    public void weaponsoundShot()
    {

    }

    public void weaponsoundReload()
    {

    }
}
