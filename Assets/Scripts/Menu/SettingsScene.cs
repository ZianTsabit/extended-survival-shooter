using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScene : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        Debug.Log("start");
        if( PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            Debug.Log("no key");
            SetMusicVolume();
            SetSfxVolume();
        }

    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("musicVol", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSfxVolume()
    {
        float sfxvolume = sfxSlider.value;
        myMixer.SetFloat("sfxVol", Mathf.Log10(sfxvolume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxvolume);
    }

    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        if(PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }  
        SetMusicVolume();
        SetSfxVolume();
    }
}
