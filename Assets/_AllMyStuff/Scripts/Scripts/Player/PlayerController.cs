using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;

    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //if LMB is pressed, move to raycast hit point
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //move player to position (pickup if collides with item)
                //Debug.Log("we hit" + hit.collider.name + " " + hit.point);
                motor.MoveToPoint(hit.point);
            }
        }
        //if (Input.GetMouseButton(1))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //
        //    if (Physics.Raycast(ray, out hit, 100, movementMask))
        //    {
        //        //move player to position (pickup if collides with item)
        //        Debug.Log("we hit" + hit.collider.name + " " + hit.point);
        //        motor.MoveToPoint(hit.point);
        //    }
        //}
    }

    void CheckMouseDown()
    {
        

    }
    
}
