using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    bool isMoved=false;

    void Start()
    {
        text1.enabled=false;
        text2.enabled=false;
        text3.enabled=false;
        
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isMoved = true;
        }
        if (isMoved)
        {
            StartCoroutine(FadeText(text1,2,0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "trigger1")
        {
            text1.enabled=true;
        }
        else if (this.gameObject.name == "trigger2")
        {
            text2.enabled=true;
        }else if (this.gameObject.name == "trigger3")
        {
            text3.enabled=true;
        }else if(this.gameObject.name == "trigge3"){
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.name == "trigger2")
        {
            text2.enabled = false;
        }
        if (this.gameObject.name == "trigger3")
        {
            StartCoroutine(FadeText(text3,1,0));
        }
    }
    
    IEnumerator FadeText(TextMeshProUGUI text, float duration, float newAlpha) {
    float originalAlpha = text.color.a;
    float elapsed = 0f;

    while (elapsed < duration) {
        elapsed += Time.deltaTime;
        float alpha = Mathf.Lerp(originalAlpha, newAlpha, elapsed / duration);
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        yield return null;
    }
}
}
