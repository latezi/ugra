using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class lifttrigger : MonoBehaviour
{
    public liftteleport lift;
    List<GameObject> z;
    public GameObject parent;
    public kgjfhoi next;
    public animatcii tthis;

    private void Start()
    {
        lift = GetComponentInParent<liftteleport>();
        z = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("111");
        if (!other.CompareTag("button") && !other.CompareTag("player"))
        {
            if (other.GetComponent<magazine>()!= null || other.GetComponent<pistolet>() != null || other.GetComponent<ovmagaz>() != null || other.GetComponent<avtomat>() != null || other.CompareTag("gren") || other.GetComponent<swordd>()!= null || other.GetComponent<cheee>() != null)
            {
                z.Add(other.gameObject);
            }           
        }
        else
        {
            if (other.CompareTag("player"))
            {
                tthis.dveri();
                Debug.Log("1");
            }
            Debug.Log("11");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<magazine>() != null || other.GetComponent<pistolet>() != null || other.GetComponent<ovmagaz>() != null || other.GetComponent<avtomat>() != null || other.CompareTag("gren") || other.GetComponent<swordd>() != null || other.GetComponent<cheee>() != null)
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
            if (t != null)
            {
                if (!t.GetComponent<XRGrabInteractable>().isSelected)
                {
                    if (t.GetComponent<cheee>() != null)
                    {
                        if (!t.GetComponent<cheee>().onplace)
                        {
                            t.transform.parent = spawnobject.transform;
                        }
                    }
                    else
                    {
                        t.transform.parent = spawnobject.transform;
                    }
                }
            }
            
        }
        lift.player.transform.position = lift.kuda.transform.position - new Vector3(0,1,0);
        spawnobject.transform.position = lift.kuda.transform.position;
        next.otkrutue();
        currentweapon.igrok_na_meste = true;
    }
}
