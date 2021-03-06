
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{


    public Text Obikolki;

    public int lap = 1;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("LAP + 1 trqbva da stane");
            Obikolki.text = " Lap  " + lap++;
        }
    }
}