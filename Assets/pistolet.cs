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

    public GameObject elline;
    public Transform elline_niz;
    public Transform elline_verh;

    public GameObject laserhandler;

    public bool c = false;

    public void OnEnable()
    {
        xgab.activated.AddListener(strelba);
        xgab.selectEntered.AddListener(fdgasdfg);
        xgab.selectExited.AddListener(sfkdfk);
        seeterline(0);
    }

    public void OnDisable()
    {
        xgab.activated.RemoveListener(strelba);
        xgab.selectEntered.RemoveListener(fdgasdfg);
        xgab.selectExited.RemoveListener(sfkdfk);
    }

    private void sfkdfk(SelectExitEventArgs arg0)
    {

    }

    private void fdgasdfg(SelectEnterEventArgs arg0)
    {

    }


    private void strelba(ActivateEventArgs arg0)
    {
        fire();
    }

    void Update()
    {
        /*if ()
        {

        }*/
        
    }


    public void fire()
    {
        if (currentmagazine != null && Ismagazineonplace && currentmagazine.bullets>=12.5)
        {
            weaponsoundShot();
            RaycastHit hit;
            if (Physics.Raycast(rayorig.position, rayorig.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                lasercreation(hit.point);
                if (hit.transform.GetComponent<Itarget>() != null)
                {                    
                    if (hit.transform.GetComponent<targetcube>() != null)
                    {
                        hit.transform.GetComponent<targetcube>().catchbullet(pistol_damage);
                        Debug.Log(hit.transform.GetComponent<targetcube>().hps);
                    }
                }
            }
            currentmagazine.bullets -= (float)12.5;
            seeterline(currentmagazine.bullets);
            if (currentmagazine.bullets == 0)
            {
                //currentmagazine.perezar(this);
            }
        }
        else
        {
            weaponsoundReload();
        }
    }

    public void seeterline(float persents)
    {
        elline.transform.localPosition = calculline(elline_niz.localPosition, elline_verh.localPosition, persents);
    }
    public Vector3 calculline(Vector3 a, Vector3 b, float persents)
    {
        return new Vector3(a.x, a.y, a.z + (b.z-a.z)*persents/100); //(float)4.29 - (((float)4.29 + (float)1.67) * persents / 100)
    }

    private void lasercreation(Vector3 point)
    {
        GameObject localhandler = Instantiate(laserhandler, rayorig.position, Quaternion.identity);
        LineRenderer a = localhandler.GetComponent<LineRenderer>();
        a.enabled = true;
        a.SetPosition(0, rayorig.position);
        a.SetPosition(1, point);    
    }
    public void ChangeAlpha(Material mat, float alphaValue)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        mat.SetColor("_Color", newColor);
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
