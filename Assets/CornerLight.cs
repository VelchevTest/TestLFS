using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerLight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject GreenLight;
    public float sec = 14f;
    public bool infiniteBool = true;
    public bool isitRed;
    public bool isitGreen;
    public GameObject stopTrigger;

    // Start is called before the first frame update
    void Start()
    {
        isitRed = false;
        isitGreen = false;
        redLight.gameObject.SetActive(true);
        yellowLight.gameObject.SetActive(false);
        GreenLight.gameObject.SetActive(false);
        StartCoroutine(TrafficLightSystemCorner());
    }
    IEnumerator TrafficLightSystemCorner()
    {

        while (infiniteBool == true)
        {

            
            yield return new WaitForSecondsRealtime(15);

            GreenLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);
            isitRed = true;
            isitGreen = false;
            stopTrigger.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            yellowLight.gameObject.SetActive(false);
            redLight.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(20);
            redLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);
            isitGreen = true;
            isitRed = false;
            stopTrigger.SetActive(false);
            yield return new WaitForSecondsRealtime(3);
            yellowLight.gameObject.SetActive(false);
            GreenLight.gameObject.SetActive(true);

        }
    }

}
