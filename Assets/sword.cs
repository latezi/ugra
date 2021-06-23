using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public int sword_dmg = 3;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Itarget>() != null)
        {
            if (other.GetComponent<targetcube>() != null)
            {
                other.GetComponent<targetcube>().catchbullet(sword_dmg);
                Debug.Log(other.GetComponent<targetcube>().hps);
            }
        }    
    }
}
