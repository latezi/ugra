using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class kgjfhoi : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent m_MyEvent;
    float p = 5;
    bool t = true;

    // Update is called once per frame
    void Update()
    {
        /*p -= Time.deltaTime;
        if (t && p<0)
        {
            m_MyEvent.Invoke();
            currentweapon.vklucheniekubov();
            currentweapon.igrok_na_meste = true;
            t = false;
        }*/
    }
    public void otkrutue()
    {
        m_MyEvent.Invoke();
    }
}
