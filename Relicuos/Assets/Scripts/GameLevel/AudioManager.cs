using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string SoundPref = "SoundPref";
    private int _firstPlayInt;
    public Slider soundSlider;
    private float _soundSliderFloat;
    public AudioSource[] audioSource;
    public AudioMixer audioMixer;

    public void SetLevelForAudioMixer(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
    
    private void Start()
    {
        IsThisFirstPlay();
    }

    public void IsThisFirstPlay()
    {
        _firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (_firstPlayInt == 0)
        {
            _soundSliderFloat = 1f;
            soundSlider.value = _soundSliderFloat;
            PlayerPrefs.SetFloat(SoundPref, _soundSliderFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            _soundSliderFloat = PlayerPrefs.GetFloat(SoundPref);
            soundSlider.value = _soundSliderFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(SoundPref, soundSlider.value);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = soundSlider.value;
        }
    }
}
