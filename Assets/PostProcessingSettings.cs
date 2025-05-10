using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System;


public class PostProcessingSettings : MonoBehaviour
{
    public Volume volume;
    public Slider contrastSlider;
    ColorAdjustments colorAdjustments;
    void Start()
    {
        if(!volume.profile.TryGet(out colorAdjustments)){
        Debug.LogError("No Colors");
        }

        contrastSlider.value = PlayerPrefs.GetFloat("contrast",.33f);

    }

    void Update()
    {

    }
    public void SetContrast(){
    colorAdjustments.contrast.value = Mathf.Lerp(-50f,100f,contrastSlider.value);
    PlayerPrefs.SetFloat("contrast", contrastSlider.value);
    }
}
