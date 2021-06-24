using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class lift : MonoBehaviour
{
    public XRRig aaa;
    public GameObject aaaa;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("player entered");
        }
        Debug.Log("entered");
        //aaa.transform.position = aaaa.transform.position;
    }
}
