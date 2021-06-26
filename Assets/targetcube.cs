using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class targetcube : MonoBehaviour, Itarget
{
    public int hps = 1;
    public AudioSource Sound;
    public firsttartgets gde;
    public void catchbullet(int dam)
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
}
