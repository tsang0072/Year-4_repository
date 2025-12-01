using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    private void Start() {
        SetMusicVolume();
    }

public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*25);
    }
}
