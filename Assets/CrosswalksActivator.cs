using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalksActivator : MonoBehaviour
{
    public GameObject CWCL;


   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
        {
            CWCL.gameObject.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
        {
            CWCL.gameObject.SetActive(false);
        }
    }
}

    

