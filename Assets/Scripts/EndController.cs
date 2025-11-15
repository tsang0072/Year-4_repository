using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    SceneController sceneController;
    private void Start() {
        sceneController=SceneController.instance;
    }
    private void OnTriggerEnter(Collider other) {
        
        SceneManager.LoadScene(3);
    }
}
