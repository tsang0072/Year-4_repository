using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private DoorController[] allDoors;
    public bool isDied=false;

    
    
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
        sceneController = SceneController.instance;
    }

    public void PlayerDie()
    {
        isDied = true;
        Debug.Log("Player restart");
        foreach (DoorController door in allDoors)
        {
            door.ResetDoor();
        }
        sceneController.Fade();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale=0;
    }
    public void ContinueGame()
    {
        Time.timeScale=1;
    }    public void SiwtchScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    
}
