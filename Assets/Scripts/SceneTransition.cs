using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => Load(sceneName));

    }

    void Load(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName); //staticにアクセスする
        SceneManager.LoadScene(sceneName);
    }
}
