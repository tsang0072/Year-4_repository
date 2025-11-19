using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    string sceneName;
    public GameObject pauseMenu;
    
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
    private void Start() 
    {
        scenefade=GetComponentInChildren<Scenefade>();
        
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Scene currentScene = SceneManager.GetActiveScene ();
		    sceneName = currentScene.name;
            if (sceneName == "InGame")
            {
                pauseMenu.SetActive(true);
                Time.timeScale=0;
            }
        }
    }
    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1;
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
    public void LevelFade()
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

    public IEnumerator LevelFadeCoroutine()
    {
        //yield return scenefade.FadeOutCoroutine(1);
        yield return scenefade.FadeInCoroutine(1);
        //playerController.Isfreezed=false;
        //player.gameObject.GetComponent<PlayerController>().enabled=false;
    }


}
