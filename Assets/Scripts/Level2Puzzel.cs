using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Puzzel : MonoBehaviour
{
    // Animator bottunController;
    // bool buttonPress_1 = false;
    // bool buttonPress_2 = false;
    // bool buttonPress_3 = false;
    // bool buttonPress_4 = false;
    // bool buttonPress_5 = false;
    // public GameObject[] doors;
    // bool door1Open=false;
    // bool door2Open=false;
    // bool door3Open=true;
    // bool door4Open=true;
    // bool door5Open=false;
    // bool door6Open=false;
    // bool door7Open=false;
    // bool door8Open=false;
    // bool door9Open=false;
    // bool door10Open=false;

    // void Start()
    // {
    //     bottunController = GetComponent<Animator>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (buttonPress_1 && Input.GetKeyDown(KeyCode.E))
    //     {
    //         bottunController.SetTrigger("TrPress");
    //         if (!door1Open)
    //         {
    //             GameObject.Find("Door1").GetComponent<Animator>().SetTrigger("TrOpen");
    //             door1Open = true;
    //         }
    //         else if (door1Open)
    //         {
    //             GameObject.Find("Door1").GetComponent<Animator>().SetTrigger("TrClose");
    //             door1Open = false;
    //         }
    //         if (door2Open)
    //         {
    //             GameObject.Find("Door2").GetComponent<Animator>().SetTrigger("TrClose");
    //             door2Open = false;
    //         }
    //         else if (!door2Open)
    //         {
    //             GameObject.Find("Door2").GetComponent<Animator>().SetTrigger("TrOpen");
    //             door2Open = true;
    //         }
    //     }
    // }

    [Header("Doors controlled by this button")]
    public List<DoorController> controlledDoors = new List<DoorController>();

    private bool isPressed = false;

    void Update()
    {
        if (isPressed && (Input.GetKeyDown(KeyCode.E))){
            PressButton();
            Debug.Log("Level2 pressed");
        }
    }

    
    

    private void PressButton()
    {

        foreach (var door in controlledDoors)
        {
            door.TriggerDoor();
        }
        // Optional: Play button press animation or sound
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            Debug.Log("Level2 press ready");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = false;
        }
    }
}
