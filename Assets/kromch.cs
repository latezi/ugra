using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class kromch : MonoBehaviour
{
    public bool exploretime = false;
    public float timer = 8.0f;
    public float extimer;
    public float maxDistance = 10f;
    public float grenade_damage = 10f;
    public Itarget[] targets1;
    public GameObject chekka;

    public void Update()
    {
        if (exploretime)
        {
            if (extimer <= 0)
            {
                Debug.Log("explore");
                targets1 = currentweapon.Targets.ToArray();
                foreach (var o in targets1)
                {
                    if (o != null)
                    {
                        if (Vector3.Distance(transform.position, o.distance()) < maxDistance)
                        {
                            Debug.Log("ranen");
                            o.catchbullet(Vector3.Distance(transform.position, o.distance() / grenade_damage));
                        }
                    }
                }
                chekka.transform.parent = null;
                Destroy(gameObject);
            }
            else
            {
                extimer -= Time.deltaTime;
            }
        }
    }
}
