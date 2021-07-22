using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class kgjfhoi : MonoBehaviour
{

    public UnityEvent m_MyEvent;

    void Update()
    {

    }
    public void otkrutue()
    {
        m_MyEvent.Invoke();
    }
}
