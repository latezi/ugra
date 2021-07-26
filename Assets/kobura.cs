using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kobura : MonoBehaviour
{
    public Transform Camera;
    public Transform Camera1;
    void LateUpdate()
    {
        transform.position = new Vector3(Camera.position.x, Camera.position.y-0.427f, Camera.position.z);//-0.086f
        transform.rotation = new Quaternion(transform.rotation.x, Camera1.rotation.y, transform.rotation.z, Camera1.rotation.w);
    }
}
