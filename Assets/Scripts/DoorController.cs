using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator bottunController;
    // public GameObject door1;
    // public GameObject door2;
    bool buttonPressed = false;
    // bool door2Triggerd = false;

    void Start()
    {
        bottunController = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // if (!buttonPressed)
        // {
        //     Debug.Log("Can press E");
       
        //      bottunController.SetBool("buttonPressed",true);
        //     buttonPressed=true;
        // }
        // if (buttonPressed)
        // {
        //     bottunController.SetBool("buttonPressed", false);
        //     buttonPressed=false;
        // }
        if (Input.GetKeyDown(KeyCode.E))
        {
            bottunController.Play("button_press",0,0.2f);
            Debug.Log("pressed E");

        }
    }
}
