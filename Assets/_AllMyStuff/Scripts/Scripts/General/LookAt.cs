using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] bool cameraMain;

    // Update is called once per frame
    void LateUpdate()
    {
        if(cameraMain)
            transform.LookAt(Camera.main.transform);
        else
            transform.LookAt(target);
        transform.Rotate(offset);
    }
}
