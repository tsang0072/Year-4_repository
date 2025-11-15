using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public GameObject spiderText;
    public GameObject overTalkSpider;
    public GameObject overTalkRat;
    public GameObject ratText;
    public GameObject mosquitoText;
    bool isSpider = false;
    bool isRat = false;
    bool isMosquito = false;
    int SpiderCount = 0;
    int RatCount = 0;

    public TextMeshProUGUI dialogueNote;

    void Start()
    {
        spiderText.SetActive(false);
        ratText.SetActive(false);
        mosquitoText.SetActive(false);
        overTalkRat.SetActive(false);
        overTalkSpider.SetActive(false);

        dialogueNote.enabled=false;
      
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isSpider)
            {
                SpiderCount++;
                if (SpiderCount <= 3)
                {
                    spiderText.SetActive(true);
                    Debug.Log(SpiderCount);
                    StartCoroutine(TextOut(spiderText));
                }
                else if (SpiderCount > 3)
                {
                    overTalkSpider.SetActive(true);
                    StartCoroutine(TextOut(overTalkSpider));
                }
                
                
            }else if (isRat)
            {
                RatCount++;
                if (RatCount <= 3)
                {
                    ratText.SetActive(true);
                    Debug.Log("talking to rat");
                    StartCoroutine(TextOut(ratText));
                }else if (RatCount > 3)
                {
                    overTalkRat.SetActive(true);
                    StartCoroutine(TextOut(overTalkRat));
                }
            }else if (isMosquito)
            {
                mosquitoText.SetActive(true);
                StartCoroutine(TextOut(mosquitoText));
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        dialogueNote.enabled=true;
        if (this.gameObject.name == "Spider")
        {
            isSpider = true;
        }
        if (this.gameObject.name == "Rat")
        {
            isRat = true;
        }
        if (this.gameObject.name == "mosquitos")
        {
            isMosquito = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        isSpider = false;
        isRat = false;
        isMosquito=false;

        dialogueNote.enabled=false;
    }
    
    IEnumerator TextOut(GameObject gameObject)
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
