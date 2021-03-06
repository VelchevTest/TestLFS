using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public float distanceFromCamera;
    public float cameraRotation;
    void Update()
    {
        Vector3 newRotation = new Vector3(cameraTransform.transform.eulerAngles.x, cameraTransform.transform.eulerAngles.y, cameraTransform.transform.eulerAngles.z);
        this.transform.eulerAngles = newRotation;
        Vector3 resultingPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
        transform.position = new Vector3(resultingPosition.x, transform.position.y, resultingPosition.z);
    }
}