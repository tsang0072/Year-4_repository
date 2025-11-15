using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    SceneController sceneController;
    void Start()
    {
        sceneController=SceneController.instance;   
    }

    private void OnTriggerEnter(Collider other)
    {
        sceneController.Fade();
    }
}
