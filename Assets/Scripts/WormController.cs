using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    Animator wormAnimator;
    GameManager gameManager;
    bool isOut=false;
    void Start()
    {
        wormAnimator = GetComponent<Animator>();
        gameManager=GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOut)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()?.Die();
            gameManager.PlayerDie();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("worm out");
            wormAnimator.SetTrigger("isOut");
            isOut=true;

            other.GetComponent<PlayerController>()?.Die();
            gameManager.PlayerDie();
        }
    }
    IEnumerator HoldSeconds()
    {
        yield return new WaitForSeconds(20);
    }
}
