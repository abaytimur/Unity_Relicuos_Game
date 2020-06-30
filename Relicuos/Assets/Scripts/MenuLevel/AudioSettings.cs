using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Object = UnityEngine.Object;

public class AudioSettings : MonoBehaviour
{
    private static readonly string SoundPref = "SoundPref";

    private float _soundSliderFloat;
    public AudioSource[] audioSource;
    private int _firstPlayInt;
    
    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        _soundSliderFloat = PlayerPrefs.GetFloat(SoundPref);

        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = _soundSliderFloat;
        }
    }

}
