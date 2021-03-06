using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightActivator : MonoBehaviour
{
    public List<GameObject> RedLights;
    // Start is called before the first frame update
    void Start()
    {
        RedLights.Add(GameObject.FindGameObjectWithTag("RedLight"));
    }

    
}
