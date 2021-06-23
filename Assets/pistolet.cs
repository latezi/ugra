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

    public void Awake()
    {
        
    }

    private void OnEnable()
    {
        xgab.selectEntered.AddListener(podobran);
        xgab.selectExited.AddListener(opushen);
        xgab.activated.AddListener(strelba);
        xgab.deactivated.AddListener(stroppp);
    }

    private void opushen(SelectExitEventArgs arg0)
    {
        if (currentweapon.currentweapon_1!= null && currentweapon.currentweapon_1.Equals(this))
        {
            currentweapon.currentweapon_1 = null;
        }
        else
        {
            currentweapon.currentweapon_2 = null;
        }      
    }

    private void stroppp(DeactivateEventArgs arg0)
    {

    }

    private void OnDisable()
    {
        xgab.selectEntered.RemoveListener(podobran);
        xgab.selectExited.RemoveListener(opushen);
        xgab.activated.RemoveListener(strelba);
        xgab.deactivated.RemoveListener(stroppp);
    }

    private void podobran(SelectEnterEventArgs arg0)
    {
        if (currentweapon.currentweapon_1 == null)
        {
            currentweapon.currentweapon_1 = this;
        }
        else
        {
            currentweapon.currentweapon_2 = this;
        }
    }

    private void strelba(ActivateEventArgs arg0)
    {
        fire();
    }

    public void setter(bool p)
    {
        this.Ismagazineonplace = p;
    }

    public void settermag(XRBaseInteractable interactable)
    {
        this.currentmagazine = interactable.GetComponent<magazine>();
    }
    public void fire()
    {
        Debug.LogWarning(currentmagazine != null);
        Debug.LogWarning(currentweapon.currentweapon_1 != null && this.Equals(currentweapon.Currentweapon_1));
        Debug.LogWarning(currentweapon.currentweapon_2 != null && this.Equals(currentweapon.Currentweapon_2));
        Debug.LogWarning(Ismagazineonplace);

        if (currentmagazine != null && (this.Equals(currentweapon.Currentweapon_1) || this.Equals(currentweapon.Currentweapon_2)) && Ismagazineonplace)
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
            /*if (currentmagazine == null)
                Debug.LogWarning("not magazine");
            if (!Ismagazineonplace)
                Debug.LogWarning("not on place");
            if (currentmagazine.bullets == 0)
            {
                weaponsoundReload();
                Debug.LogWarning("havent patrons");
            }*/
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
