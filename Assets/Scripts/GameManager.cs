using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public static GameManager instance;
    private DoorController[] allDoors;
    
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
        allDoors = FindObjectsOfType<DoorController>();    
    }

    public void PlayerDie()
    {
        Debug.Log("Player restart");
        foreach (DoorController door in allDoors)
        {
            door.ResetDoor();
        }

    }
}
