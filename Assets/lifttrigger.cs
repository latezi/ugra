using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class lifttrigger : MonoBehaviour
{
    public liftteleport lift;
    List<GameObject> z;
    public GameObject parent;

    private void Start()
    {
        lift = GetComponentInParent<liftteleport>();
        z = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("button") && !other.CompareTag("player"))
        {
            if (other.GetComponentInParent<avtagchecker>()== null && other.GetComponentInParent<socketwithtagcheck>() == null && other.GetComponentInParent<sword>() == null)
            {
                z.Add(other.gameObject);
            }           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("button") && !other.CompareTag("player"))
        {
            z.Remove(other.gameObject);
        }      
    }
    public void teleport()
    {
        GameObject spawnobject = new GameObject();
        spawnobject.transform.position = parent.transform.position;
        foreach (var t in z)
        {
            if (!t.GetComponent<XRGrabInteractable>().isSelected)
            {
                t.transform.parent = spawnobject.transform;
            }
            
        }
        lift.player.transform.position = lift.kuda.transform.position - new Vector3(0,1,0);
        spawnobject.transform.position = lift.kuda.transform.position;
    }
}
