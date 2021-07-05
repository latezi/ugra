using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class targetcube : MonoBehaviour, Itarget
{
    public float hps = 1;
    public bool readytodam = false;

    public bool igrok_na_meste = false;
    public bool kk = true;

    public bool cansetmaterial = true;
    MeshRenderer material;
    public Material material1;
    public Material material2;

    public float randomtimer;
    public float animationtimer = 2.0f;

    public AudioSource Sound;
    public firsttartgets gde;

    float min = 15f;
    float max = 25f;

    private void Start()
    {
        material = GetComponent<MeshRenderer>();
        randomtimer = Random.Range(min, max);
    }

    private void OnEnable()
    {
        currentweapon.adder(this);
    }
    public void catchbullet(float dam)
    {
        if (readytodam)
        {
            sound();
            hps -= dam;
            if (hps < 1)
            {
                currentweapon.Targets.Remove(this);
                Destroy(gameObject);
                gde.newcube();
            }
        }
        else
        {
            damagetoplayer();
        }
    }
    void Update()
    {
        if (igrok_na_meste)
        {
            if (kk)
            {
                if (randomtimer < 0)
                {
                    readytodam = true;
                    cansetmaterial = true;
                    kk = false;
                }
                else
                {
                    randomtimer -= Time.deltaTime;
                }
            }
            
        }
        if (readytodam)
        {
            if (cansetmaterial)
            {
                material.material = material2;
                cansetmaterial = false;
            }
            if (animationtimer < 0)
            {
                damagetoplayer();
                material.material = material1;
                kk = true;
                cansetmaterial = false;
                randomtimer = Random.Range(min, max);
                readytodam = false;
                animationtimer = 2.0f;
            }
            else
            {
                animationtimer -= Time.deltaTime;
            }
        }
    }

    public void sound()
    {
        Sound.Play();
    }

    public void Animation()
    {
        
    }

    public void setplayer()
    {
        igrok_na_meste = true;
        Debug.Log("ya prishel");
    }

    public void damagetoplayer()
    {
        Debug.Log("ya tebya ranil!!!");
    }

    public Vector3 distance()
    {
        return transform.position;
    }
}
