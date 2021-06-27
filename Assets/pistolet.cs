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

    public void OnEnable()
    {
        xgab.selectEntered.AddListener(podobran);
        xgab.selectExited.AddListener(opushen);
        xgab.activated.AddListener(strelba);
        xgab.deactivated.AddListener(stroppp);
        //base.OnEnable();
    }

    private void opushen(SelectExitEventArgs arg0)
    {
        /*if (currentweapon.currentweapon_1!= null && currentweapon.currentweapon_1.Equals(this))
        {
            currentweapon.currentweapon_1 = null;
        }
        else
        {
            currentweapon.currentweapon_2 = null;
        }  */    
    }

    private void stroppp(DeactivateEventArgs arg0)
    {

    }

    public void OnDisable()
    {
        xgab.selectEntered.RemoveListener(podobran);
        xgab.selectExited.RemoveListener(opushen);
        xgab.activated.RemoveListener(strelba);
        xgab.deactivated.RemoveListener(stroppp);
        //base.OnDisable();
    }

    private void podobran(SelectEnterEventArgs arg0)
    {
        /*if (currentweapon.currentweapon_1 == null)
        {
            currentweapon.currentweapon_1 = this;
        }
        else
        {
            currentweapon.currentweapon_2 = this;
        }*/
    }

    private void strelba(ActivateEventArgs arg0)
    {
        fire();
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
