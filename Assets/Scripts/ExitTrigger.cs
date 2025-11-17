using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    SceneController sceneController;
    public GameObject blockBox;
    
    void Start()
    {
        sceneController=SceneController.instance;   
        blockBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        sceneController.LevelFade();
    }
    void OnTriggerExit(Collider other)
    {
        blockBox.SetActive(true);
    }
}
