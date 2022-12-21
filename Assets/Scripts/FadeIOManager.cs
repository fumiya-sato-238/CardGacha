using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//画面遷移のフェードイン・アウトの処理
public class FadeIOManager : MonoBehaviour
{
    //fadeIn/Outの演出時間
    float fadeTime = 0.25f;
    //シングルトン化
    public static FadeIOManager instance;
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

    public CanvasGroup canvasGroup;
    public void FadeOut()
    {
        //ボタンを押せないようにRayをブロック
        canvasGroup.blocksRaycasts = true;
        //アルファ値を1に1秒かけてする
        canvasGroup.DOFade(1,fadeTime).OnComplete(() => canvasGroup.blocksRaycasts = false);
    }
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        //アルファ値を0に1秒かけてする
        canvasGroup.DOFade(0,fadeTime).OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        //FadeOutを1秒しつつ、完了後にactionとFadeInをする
        canvasGroup.DOFade(1,fadeTime).OnComplete(() => {
            action();
            FadeIn();
        });
    }

}
