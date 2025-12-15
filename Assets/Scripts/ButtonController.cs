using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Doors controlled by this button")]
    public List<DoorController> controlledDoors = new List<DoorController>();
    private bool isPressed = false;

    Animator bottunController;
    AudioManager audioManager;

    void Start()
    {
        bottunController = GetComponent<Animator>();
        audioManager=AudioManager.instance;
    }

    void Update()
    {
        if (isPressed && (Input.GetKeyDown(KeyCode.E))){
            PressButton();
            audioManager.PlayButtonSFX();
            audioManager.PlayDoorSFX();
            Debug.Log("Level2 pressed");
        }
    } 
    private void PressButton()
    {
        bottunController.SetTrigger("TrPress");
        foreach (var door in controlledDoors)
        {
            door.TriggerDoor();
        }
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
