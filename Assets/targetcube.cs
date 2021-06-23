using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetcube : MonoBehaviour, Itarget
{
    public int hps = 100;
    public AudioSource Sound;

    public void catchbullet(int dam)
    {
        sound();
        hps -= dam;
        if (hps <1)
        {
            Destroy(gameObject);
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
