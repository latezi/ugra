using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatcii : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void dveri()
    {
        anim.SetBool("otkryt_zakryt", !anim.GetBool("otkryt_zakryt"));
    }

    public void zakkrytie()
    {
        anim.SetBool("otkryt_zakryt", false);
    }
}
