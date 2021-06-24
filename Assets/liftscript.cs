using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class liftscript : MonoBehaviour
{
    public GameObject leftdoor;
    public GameObject rightdoor;

    Collider Collider;
    public float u = 0.001f;

    public bool a = false;
    public bool b = true;

    private void Update()
    {
        if (a)
        {
            Vector3 dsf = leftdoor.transform.position;
            dsf.z += u;
            leftdoor.transform.position = dsf;
        }        
    }

}
