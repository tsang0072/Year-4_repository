
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    VideoPlayer video;
    public string sceneName;
    SceneController sceneController;
   
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
        sceneController=SceneController.instance;

    }


     void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        sceneController.ChangeScene(sceneName);
        //SceneManager.LoadScene(sceneName);
    }

}
