using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.Mathematics;
public class AudioSettings : MonoBehaviour
{

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundFXSlider;
    public AudioMixer audioMixer;
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume",.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume",.5f);
        soundFXSlider.value = PlayerPrefs.GetFloat("SFXVolume",.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetVolume(string groupName, float value){
        float adjustedValue = Mathf.Log10(value) * 20f; //Decibel Value 
        if(value == 0){
            adjustedValue = -80f;
        }
        audioMixer.SetFloat(groupName, adjustedValue);
    }

    public void SetMasterVolume(){
        SetVolume("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void SetMusicVolume(){
        SetVolume("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void SetSoundFXVolume(){
        SetVolume("SFXVolume", soundFXSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", soundFXSlider.value);
    }
}
