using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class liftteleport : MonoBehaviour
{
    public bool isplayerinlift = false;
    public GameObject kuda;
    public List<GameObject> kto;
    public XRRig player;

    private void Start()
    {
        kto = new List<GameObject>();
    }
    
    public void teleport()
    {
        player.transform.position = kuda.transform.position;
        foreach(var t in kto)
        {           
            if(t.GetComponent<grenade>()!= null)
            {
                t.GetComponent<grenade>().gameObject.transform.position = kuda.transform.position;
                Debug.Log("g");
            }
            if (t.GetComponent<pistolet>() != null)
            {
                t.GetComponent<pistolet>().gameObject.transform.position = kuda.transform.position;
                Debug.Log("p");
            }
            if (t.GetComponent<avtomat>() != null)
            {
                t.GetComponent<avtomat>().gameObject.transform.position = kuda.transform.position;
                Debug.Log("a");
            }
            if (t.GetComponent<ovmagaz>() != null)
            {
                t.GetComponent<ovmagaz>().gameObject.transform.position = kuda.transform.position;
                Debug.Log("am");
            }
            if (t.GetComponent<magazine>() != null)
            {
                t.GetComponent<magazine>().gameObject.transform.position = kuda.transform.position;
                Debug.Log("m");
            }
            if (t.GetComponent<swordd>() != null)
            {
                t.GetComponent<swordd>().gameObject.transform.position = kuda.transform.position;
                Debug.Log("s");
            }
        }
    }
}
