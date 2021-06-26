using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class targetcube : MonoBehaviour, Itarget
{
    public float hps = 1;
    public AudioSource Sound;
    public firsttartgets gde;

    private void OnEnable()
    {
        currentweapon.adder(this);
    }
    public void catchbullet(float dam)
    {
        sound();
        hps -= dam;
        if (hps <1)
        {
            Destroy(gameObject);
            gde.newcube();
        }              
    }

    public void sound()
    {
        Sound.Play();
    }

    public void Animation()
    {
        
    }

    public Vector3 distance()
    {
        return transform.position;
    }
}
