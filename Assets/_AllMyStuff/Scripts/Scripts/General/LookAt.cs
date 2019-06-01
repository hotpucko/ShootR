using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(target);
        transform.Rotate(offset);
    }
}
