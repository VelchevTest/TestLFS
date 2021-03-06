using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public GameObject RayCastShooter;
    public vehicleAiController VAIC;
    public Rigidbody rb;
    public float xVelocity;


    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Car");
        LayerMask Redlight = LayerMask.GetMask("RedLight");
        LayerMask Pedestrian = LayerMask.GetMask("Pedestrian");
        RaycastHit hit;
        xVelocity = rb.velocity.magnitude;
       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 8f, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
           // Debug.Log("Did Hit" + hit.distance);
            VAIC.totalPower = (xVelocity >= 0.15f) ? -700 : -0f; // ? Means then , : means else
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
          //  Debug.Log("Did not Hit");
            VAIC.totalPower = 25f;
        }
        //cherven svetofar WAIT FULL STOP
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10.5f, Redlight))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
           // Debug.Log("Did Hit" + hit.distance);
            VAIC.totalPower = (xVelocity >= 0.15f) ? -650F : 0f; // ? Means then , : means else;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7.5f, Pedestrian))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
           // Debug.Log("Did Hit" + hit.distance);
            VAIC.totalPower = (xVelocity >= 0.15f) ? -450f : 0f; // ? Means then , : means else;
           
        }
    }




}



