using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] Toggle BGMtoggle;
    [SerializeField] Toggle SEtoggle;
    void Start()
    {
        BGMtoggle.isOn = SettingDataBool.GetBool("BGMon",true);
        SEtoggle.isOn = SettingDataBool.GetBool("SEon",true);
    }


    public void OnBGMToggleChanged()
    {
        SoundManager.instance.audioSourceBGM.enabled = BGMtoggle.isOn;
        SettingDataBool.SetBool("BGMon",BGMtoggle.isOn);
    }

    public void OnSEToggleChanged()
    {
        SoundManager.instance.audioSourceSE.enabled = SEtoggle.isOn;
        SettingDataBool.SetBool("SEon",SEtoggle.isOn);
    }
}
