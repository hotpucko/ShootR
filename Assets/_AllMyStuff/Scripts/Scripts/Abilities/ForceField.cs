using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    float damage;
    float hitForce;
    float timeToLive;
    float upForce;

    SphereCollider sphereCollider;

    public void Initialize(float damage, float radius, float hitForce, float timeToLive, float upForce)
    {
        this.damage = damage;
        this.hitForce = hitForce;
        this.timeToLive = timeToLive;
        this.upForce = upForce;
        
        transform.localScale = new Vector3(2 * radius, 2 * radius, 2 * radius);
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0.5f;
        OnAwake();
    }

    // Start is called before the first frame update
    void OnAwake()
    {
        Collider[] allOverlappingColliders = Physics.OverlapSphere(transform.position, sphereCollider.radius * transform.localScale.x);
        foreach (Collider coll in allOverlappingColliders)
        {
            if (coll.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                Rigidbody collRB = coll.GetComponent<Rigidbody>();
                if(collRB != null)
                {
                    MoveTowardsGameObject moveTowardsGameObject = coll.gameObject.GetComponent<MoveTowardsGameObject>();
                    if (moveTowardsGameObject != null)
                    {
                        moveTowardsGameObject.KnockedUp();
                    }
                    collRB.AddExplosionForce(hitForce, transform.position, sphereCollider.radius * transform.localScale.x, upForce, ForceMode.Impulse);
                }
            }
        }
        Invoke("DestroySelf", timeToLive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
        //slow down enemies
    }

    private void DestroySelf()
    {
        Destroy(transform.gameObject);
    }
}
