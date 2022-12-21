using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public AudioSource audioSourceBGM; //BGMのスピーカー
    public AudioClip[] audioClipsBGM; //BGMの素材（0:CardGacha、1:Collection）
    public AudioSource audioSourceSE; //SEのスピーカー
    public AudioClip[] audioClipsSE; //鳴らすSE

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }
    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch(sceneName)
        {
            default:
            case "CardGacha":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Collection":
            case "Setting":
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
        }
        audioSourceBGM.Play();
    }
    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]); //SEを一度だけ鳴らす
    }

    //Setting画面でBGM・SEのon/off
    // public void OnToggleChanged()
    // {
    //     if(toggle.isOn){
    //         audioSourceBGM.volume = 0.1f;
    //     }else{
    //         audioSourceBGM.volume = 0f;
    //     }
    // }
}
