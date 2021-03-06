using System.Collections;
using UnityEngine;

public class TrafficLightSwitcher : MonoBehaviour
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
        StartCoroutine(TrafficLightSystem());
    }
    IEnumerator TrafficLightSystem()
    {
        
        while (infiniteBool == true)
        {

            Debug.Log("Should wait 20sec");
            yield return new WaitForSecondsRealtime(20);

            redLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);
            isitRed = false;
            isitGreen = true;
            stopTrigger.SetActive(false);
            yield return new WaitForSecondsRealtime(2);
            yellowLight.gameObject.SetActive(false);
            GreenLight.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(15);
            GreenLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);
            isitGreen = false;
            isitRed = true;
            stopTrigger.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            yellowLight.gameObject.SetActive(false);
            redLight.gameObject.SetActive(true);

        }
    }
   
}
