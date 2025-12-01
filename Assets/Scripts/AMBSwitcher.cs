using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AMBSwitcher : MonoBehaviour
{
    AudioManager audioManager;
    public AudioSource pauseAMB;
    public AudioSource playAMB;
    void Start()
    {
        audioManager = AudioManager.instance;
    }
    void OnTriggerEnter(Collider other)
    {
        audioManager.PauseAMB(pauseAMB);
        audioManager.PlayAMB(playAMB);
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
}
