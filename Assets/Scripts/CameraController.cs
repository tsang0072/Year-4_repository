using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    // public Transform player;
    // private Vector3 offset;
    public CinemachineVirtualCamera roomCam;
    private CinemachineVirtualCamera followCam;
    
     void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //offset=transform.position-player.position;
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
