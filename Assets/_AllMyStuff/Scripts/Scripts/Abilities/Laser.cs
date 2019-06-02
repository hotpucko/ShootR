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
    Color color;

    LineRenderer lr;

    public void Initialize(float damage, float hitForce, float timeToLive, Vector3 destination, LayerMask hitMask, Color color)
    {
        this.damage = damage;
        this.hitForce = hitForce;
        this.timeToLive = timeToLive;
        this.destination = destination;
        this.hitMask = hitMask;
        this.color = color;

        lr = GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = color;
        OnAwake();
    }

    private void OnAwake()
    {
        Vector3 offset = new Vector3(0, 0.8f, 0);
        if (Physics.Raycast(new Ray(transform.position + offset, (destination - transform.position)), out RaycastHit hit, 10, hitMask))
        {
            lr.SetPositions(new Vector3[] { transform.position + new Vector3(0, 0.8f, 0), hit.point });
            if (hit.collider.GetComponent<Health>() != null)
            {
                hit.collider.GetComponent<Health>().ModifyHealth((int)damage * -1);
                Rigidbody collRB = hit.collider.GetComponent<Rigidbody>();
                if (collRB != null)
                {
                    EnemyCubeController enemyCubeController = hit.collider.gameObject.GetComponent<EnemyCubeController>();
                    if (enemyCubeController != null)
                    {
                        enemyCubeController.KnockedUp();
                    }
                    collRB.AddForce(hit.normal * hitForce, ForceMode.Impulse);
                    //collRB.AddExplosionForce(hitForce, transform.position, sphereCollider.radius * transform.localScale.x, upForce, ForceMode.Impulse);

                }
            }
        }
        else
        {
            lr.SetPositions(new Vector3[] { transform.position + offset, Vector3.Scale(new Vector3(1, 1, 1), (destination - transform.position).normalized) * 100 });
        }

        ////lr.SetPositions(new Vector3[] {transform.position, destination});

        Invoke("DestroySelf", timeToLive);
    }
    private void DestroySelf()
    {
        Destroy(transform.gameObject);
    }
}