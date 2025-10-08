using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Puzzel : MonoBehaviour
{
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
