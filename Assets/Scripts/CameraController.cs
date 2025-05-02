using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform player;
    private Vector3 offset;
    
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
        offset=transform.position-player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=offset+player.position;
    }
}
