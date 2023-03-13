using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


[System.Serializable]

public class Sound //컴포넌트 추가 불가
{
    public string name; //곡
    public AudioClip clip;
}

public class scSoundManager : MonoBehaviour
{
    #region singleton
    static public scSoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;//자기 자신의 인스턴스 할당
            DontDestroyOnLoad(gameObject); //씬 전환시 파괴되지 않음
        }
        else //만약 사운드 매니저가 두 개 이상이면 하나만 남기고 삭제
            Destroy(this.gameObject);
    }

    #endregion singleton

    public AudioMixer audioMixer;

    public Slider TotalSlider;
    public Slider bgmSlider;
    public Slider sFxSlider;




    public Sound[] effectSounds; //공격 사운드
    public Sound[] bgmSounds; //BGM 오디오 클립

    public AudioSource audioSourceBFM; //BGM재생기
    public AudioSource[] audioSourceEffects; //동시에 여러개가 재생되는 효과음은 배열

    public string[] playSoundName;

    public float bgmVol = 1.0f;
    public float effectVol = 1.0f;

    private void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }


    public void PlaySE(string _name)
    {
        for(int i =0; i< effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)
            {
                for(int j = 0; j< audioSourceEffects.Length; j++)
                {
                    if(!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
                Debug.Log("모든 가용 AudioSource가 사용 중입니다");
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니.");
    }
    public void PlayBGM(string _name)
    {
        for(int i = 0; i< bgmSounds.Length; i++)
        {
            if(_name == bgmSounds[i].name)
            {
                audioSourceBFM.clip = bgmSounds[i].clip;
                audioSourceBFM.Play();
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다");
    }
    public void StopBGM()
    {
        
                audioSourceBFM.Stop();
                return;
            
        
    }



    public void StopAllSE()
    {
        for(int i = 0; i< audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                break;
            }
        }
        Debug.Log("재생 중인" + _name + "사운드가 없습니다");
    }

    public void SetTotalVolume()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(TotalSlider.value) * 20);
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