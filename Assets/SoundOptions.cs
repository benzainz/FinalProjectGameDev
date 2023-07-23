using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        //by default if your request an int to PlayerPrefs is 0
     if (PlayerPrefs.GetInt("set default volume") != 1)
        {
            PlayerPrefs.SetInt("set default volume",1);
            //set and save sliders values 
            masterSlider.value = .1f;
            PlayerPrefs.SetFloat("master volume", .1f);

            musicSlider.value = .1f;
            PlayerPrefs.SetFloat("music volume", .1f);

            sfxSlider.value = .1f;
            PlayerPrefs.SetFloat("sfx volume", .1f);
        
        }
     else
        {
            masterSlider.value = PlayerPrefs.GetFloat("master volume");
            musicSlider.value = PlayerPrefs.GetFloat("music volume");
            sfxSlider.value = PlayerPrefs.GetFloat("sfx volume");
        }
    }

    void SetVolume(string name, float value)
    {
        float volume = Mathf.Log10(value) * 20;
        if (value == 0 )
        {
            volume = -80;
        }
        audioMixer.SetFloat(name, volume);

    }

    public void SetMasterVolume()
    {
        SetVolume("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("master volume", masterSlider.value);
    }

    public void SetMusicVolume()
    {
        SetVolume("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("music volume", musicSlider.value);

    }
    public void SetSFXVolume()
    {
        SetVolume("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("sfx volume", sfxSlider.value);

    }
}
