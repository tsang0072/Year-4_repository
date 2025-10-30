using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private DoorController[] allDoors;
    bool isDied = false;
    
    
    SceneController sceneController;
    
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
        sceneController = GetComponent<SceneController>();
    }

    public void PlayerDie()
    {
        isDied = true;
        Debug.Log("Player restart");
        foreach (DoorController door in allDoors)
        {
            door.ResetDoor();
        }

    }
    
    // public void Ending()
    // {
    //     SceneManager.LoadScene(3);
    // }
}
