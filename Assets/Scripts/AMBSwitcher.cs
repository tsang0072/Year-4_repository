using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AMBSwitcher : MonoBehaviour
{
    AudioManager audioManager;
    public AudioClip pauseClip;
    public AudioClip playClip;
    void Start()
    {
        audioManager = AudioManager.instance;
    }
    void OnTriggerEnter(Collider other)
    {
        audioManager.PauseAMB(pauseClip);
        audioManager.PlayAMB(playClip);
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
}
