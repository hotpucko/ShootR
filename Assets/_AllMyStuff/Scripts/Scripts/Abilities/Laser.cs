using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float damage;
    float hitForce;
    float timeToLive;
    Vector3 destination;
    LayerMask hitMask;

    LineRenderer lr;

    public void Initialize(float damage, float hitForce, float timeToLive, Vector3 destination, LayerMask hitMask)
    {
        this.damage = damage;
        this.hitForce = hitForce;
        this.timeToLive = timeToLive;
        this.destination = destination;
        this.hitMask = hitMask;

        lr = GetComponent<LineRenderer>();

        OnAwake();
    }

    private void OnAwake()
    {
        if (Physics.Raycast(new Ray(transform.position, (destination - transform.position)), out RaycastHit hit, 10, hitMask))
        {
            lr.SetPositions(new Vector3[] { transform.position, hit.point });
            if(hit.collider.GetComponent<Health>() != null)
            {
                hit.collider.GetComponent<Health>().ModifyHealth((int)damage * -1);
            }
        }
        else
        {
            lr.SetPositions(new Vector3[] { transform.position, Vector3.Scale(new Vector3(1, 0, 1), (destination - transform.position).normalized) * 100 });
        }

        ////lr.SetPositions(new Vector3[] {transform.position, destination});
        
        Invoke("DestroySelf", timeToLive);
    }
    private void DestroySelf()
    {
        Destroy(transform.gameObject);
    }
}
