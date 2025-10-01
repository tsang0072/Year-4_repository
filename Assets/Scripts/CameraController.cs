using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera roomCam;
    private CinemachineVirtualCamera followCam;

    
    void Start()
    {
        if (followCam == null)
        followCam = GameObject.Find("VCam_Follow").GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roomCam.Priority = 20;   // take control
            followCam.Priority = 10; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roomCam.Priority = 0;
            followCam.Priority = 20;
            
        }
    }
}
