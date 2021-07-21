using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserbehavior : MonoBehaviour
{
    LineRenderer line;
    float alpha = 1;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        alpha -= Time.deltaTime/5;
        Color p = line.material.color;
        p.a = alpha;
        line.material.color = p;
        if (alpha<0)
        {
            Destroy(this);
        }
    }
}
