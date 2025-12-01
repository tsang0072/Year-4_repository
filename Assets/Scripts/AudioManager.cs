
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip SFX_Button;
    public AudioClip SFX_Door;
    public AudioClip SFX_Sandworm;



    AudioSource AMBSource;
    AudioSource SFXSource;

     private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }else if(instance!=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        AMBSource=gameObject.AddComponent<AudioSource>();
        SFXSource=gameObject.AddComponent<AudioSource>();

        
    }
    public void PlayButton()
    {
        SFXSource.clip = SFX_Button;
        SFXSource.Play();

    }
    public void PauseAMB(AudioSource audioSource)
    {
        AMBSource = audioSource;
        AMBSource.Pause();
        
    }
    
    public void PlayAMB(AudioSource audioSource)
    {
        AMBSource = audioSource;
        AMBSource.loop = true;
        AMBSource.Play();
    }
    public void PlayButtonSFX()
    {
        SFXSource.clip = SFX_Button;
        SFXSource.Play();
    }
    public void PlayDoorSFX()
    {
        SFXSource.clip = SFX_Door;
        SFXSource.Play();
    }

    public void PlaySandwormSFX()
    {
        SFXSource.clip = SFX_Sandworm;
        SFXSource.Play();
    }
}
