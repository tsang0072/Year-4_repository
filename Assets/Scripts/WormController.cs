using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    Animator wormAnimator;
    GameManager gameManager;
    AudioManager audioManager;
    bool isOut=false;
    void Start()
    {
        wormAnimator = GetComponent<Animator>();
        gameManager = GameManager.instance;
        audioManager=AudioManager.instance;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("worm out");
            wormAnimator.SetTrigger("isOut");
            isOut = true;
            audioManager.PlaySandwormSFX();
            //StartCoroutine(HoldSeconds());

            other.GetComponent<PlayerController>()?.Die();
            gameManager.PlayerDie();
            //audioManager.PlayDoorSFX();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            isOut = false;
        }
    }
    IEnumerator HoldSeconds()
    {
        yield return new WaitForSeconds(5);
        
    }
}
