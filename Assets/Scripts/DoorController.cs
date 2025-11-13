using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum DoorType { OpenLeft, OpenRight }
    public DoorType doorType;

    public bool isOpenAtStart;
    private bool isOpen;
    private Animator animator;
    AudioManager audioManager;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager=AudioManager.instance;
        isOpen = isOpenAtStart;
        ResetDoor();

        //animator.SetTrigger("TrOpen");
    }

    public void TriggerDoor()
    {
        // isOpen = !isOpen;
        // animator.SetTrigger("TrOpen");
        if (isOpen)
        {
            animator.SetTrigger("TrClose");
            isOpen = false;
        }
        else if (!isOpen)
        {
            animator.SetTrigger("TrOpen");
            isOpen = true;
        }
    }
    public void ResetDoor()
    {
        if (isOpen != isOpenAtStart)
        {
            TriggerDoor();
        }
        
    }
}
