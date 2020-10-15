using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsSounds : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource effectSource;    

    //  public AudioClip introMusic;
    public AudioClip menuMusic;
    public AudioClip effectClick;

    public Slider Volumen, Effects;

    public static EffectsSounds instance;

    
    /*void Awake()
    {
        instance = this;
        InitializedVolumen();
    }*/


    void Start()
    {
        
        InitializedVolumen();
    }

    void Update()
    {
        
    }

    private void InitializedVolumen()
    {
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        effectSource.volume = PlayerPrefs.GetFloat("effectVolume", 1.0f);

        Volumen.value = musicSource.volume;
        Effects.value = effectSource.volume;
    }

    public void PlayEffects()
    {
        effectSource.PlayOneShot(effectClick);
    }

    public void PlaySong(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void VolumenSlider()
    {
        musicSource.volume = Volumen.value;
        PlayerPrefs.SetFloat("musicVolume", musicSource.volume);
        PlayerPrefs.Save();
    }

    public void EffectSlider()
    {
        effectSource.volume = Effects.value;
        PlayerPrefs.SetFloat("effectVolume", effectSource.volume);
        PlayerPrefs.Save();
    }
}
