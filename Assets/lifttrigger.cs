using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class lifttrigger : MonoBehaviour
{
    public liftteleport lift;
    List<GameObject> z;
    public GameObject parent;
    int i = 0;

    private void Start()
    {
        lift = GetComponentInParent<liftteleport>();
        z = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("button"))
        {
            z.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("button"))
        {
            z.Remove(other.gameObject);
        }      
    }
    public void teleport()
    {
        foreach(var t in z)
        {
            t.transform.parent = parent.transform;
        }
        parent.transform.position = lift.kuda.transform.position;
    }
}
