using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    //public Image fadeImage;

    Scenefade scenefade;

    void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start() {
        scenefade=GetComponentInChildren<Scenefade>();
    }
    
    public void SiwtchScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Fade()
    {
        StartCoroutine(FadeCoroutine());
    }

    public IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return scenefade.FadeInCoroutine(2);
    }

    public IEnumerator FadeCoroutine()
    {
        yield return scenefade.FadeOutCoroutine(2);
        yield return scenefade.FadeInCoroutine(2);
    }


}
