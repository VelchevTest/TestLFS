

using NUnit.Framework;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityStandardAssets.Vehicles.Car;

public class InteractionScript : MonoBehaviour
{
    public GameObject Reticle;
    public Camera camera;
    public GameObject CarObjectToEnable;
    public GameObject PlayerToDisable;
    public Rigidbody CarRigidBody;
    public Text InteractionText;
    public bool inRange;
    public GameObject FakeCar;
    public bool inCar;
    [SerializeField] private float CarCurrentSpeed;

    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Cars");
        RaycastHit Hit;
        Ray ray = camera.ScreenPointToRay(Reticle.transform.position);
        CarCurrentSpeed = CarRigidBody.velocity.magnitude;

        if (Physics.Raycast(Reticle.transform.position, transform.TransformDirection(Vector3.forward), out Hit, 2, mask))
        {

            InteractionText.text = " Press F to enter  " + Hit.collider.gameObject.name;
            inRange = true;
            if (Input.GetKeyDown(KeyCode.F) && inRange == true)
            {
                FakeCar.gameObject.SetActive(false);
                PlayerToDisable.gameObject.SetActive(false);
                CarObjectToEnable.gameObject.SetActive(true);
                CarObjectToEnable.gameObject.tag = ("ActiveCar");
                inCar = true;
                Debug.Log(" " + CarObjectToEnable.gameObject.tag);
                inRange = false;
               
            }
            if (Input.GetKeyDown(KeyCode.F) && inCar == true && CarCurrentSpeed <= 5f && inRange == false)
            {
                ExitCar();
                Debug.Log("ExitCar Method should have been just called.");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            InteractionText.text = "  ";
            inRange = false;
            inCar = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && inCar == true && CarCurrentSpeed <= 5f && inRange == false)
        {
            ExitCar();
            Debug.Log("ExitCar Method should have been just called.");
        }

    }
    public void ExitCar() // Exit Car Method
    {
        CarObjectToEnable = GameObject.FindGameObjectWithTag("ActiveCar");
        PlayerToDisable.transform.position = CarObjectToEnable.transform.position;
        CarObjectToEnable.SetActive(false);
        PlayerToDisable.SetActive(true);
    }



}
