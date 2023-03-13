using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class scButtonManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider bgmSlider;
    public Slider sFxSlider;


    public void MENU()
    {
        scSoundManager.instance.PlaySE("menu");
    }
    public void RESTART()
    {
        scSoundManager.instance.PlaySE("restart");
    }
    public void MAIN()
    {
        scSoundManager.instance.PlaySE("main");
        scSoundManager.instance.PlayBGM("BGM_main");

    }


    public void SetBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
    }

    public void SetSFXVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sFxSlider.value) * 20);
    }

}
