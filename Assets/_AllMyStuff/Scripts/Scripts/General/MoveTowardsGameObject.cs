using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowardsGameObject : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    bool knockedUp = false;
    Vector3 lastPosition;
    Vector3 positionDelta => transform.position - lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lastPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!knockedUp)
        {
            agent.SetDestination(target.position);
        }
        
        else
        {
            if (positionDelta.sqrMagnitude == 0)//Vector3.Distance(lastPosition, transform.position) == 0)
            {
                StandUp();
            }
        }
        lastPosition = transform.position;

    }

    private void LateUpdate()
    {
    }

    public void KnockedUp()
    {
        if(!knockedUp)
        {
            agent.SetDestination(transform.position);
            agent.isStopped = true;
            agent.ResetPath();
            agent.enabled = false;
            knockedUp = true;
        }
    }

    public void StandUp()
    {
        agent.enabled = true;
        knockedUp = false;
        agent.SetDestination(target.position);
    }
}
