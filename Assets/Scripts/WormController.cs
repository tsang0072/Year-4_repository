using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    Animator wormAnimator;
    GameManager gameManager;
    AudioManager audioManager;
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
            audioManager.PlaySandwormSFX();
            //StartCoroutine(HoldSeconds());

            other.GetComponent<PlayerController>()?.Die();
            gameManager.PlayerDie();
        }
    }
    
    IEnumerator HoldSeconds()
    {
        yield return new WaitForSeconds(5);
        
    }
}
