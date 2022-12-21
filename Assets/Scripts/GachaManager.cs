using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GachaManager : MonoBehaviour
{
    // [SerializeField] VideoPlayer gachaMovie;
    [SerializeField] GameObject normalGachaMovie;
    [SerializeField] CardController prefab;
    [SerializeField] GameObject gachaCardsPlace;
    [SerializeField] Transform parent;
    // [SerializeField] Transform canvas;
    [SerializeField] GameObject okButton;
    CardController[] card = new CardController[8];//生成したカードを格納して操作できる（Destroyなど）
    SortedDictionary<int,int> haveCards;


    void Start()
    {
        //一度保存した所持カードをロード
        haveCards = PlayerPrefsUtility.LoadDict<int,int>("haveCards");
        // if(haveCards.Count == 0)
        // {
        //     //所持カードが空の場合新しく作る
        //     SortedDictionary<int,int> haveCards = new SortedDictionary<int,int>;
        // }

        SoundManager.instance.PlayBGM("CardGacha");

        normalGachaMovie.GetComponent<VideoPlayer> ().frame = 5;
        normalGachaMovie.SetActive(false);
        okButton.SetActive(false);
        gachaCardsPlace.SetActive(false);
    }

    //-----ボタン関連-----
    public void OnGachaButton()
    {
        SoundManager.instance.PlaySE(0);

        FadeIOManager.instance.FadeOutToIn(() => normalGachaMovie.SetActive(true));
        // gachaMovie.Play();
        //ガチャのコルーチンを演出時間分（2秒）待って実行
        StopAllCoroutines();
        StartCoroutine(Gacha());
    }
    public void OnOkButton()
    {
        foreach (CardController cardController in card)
        {
            Destroy(cardController.gameObject);
        }

        okButton.SetActive(false);
        gachaCardsPlace.SetActive(false);
    }
    public void OnToCollectionButton()
    {
        SoundManager.instance.PlaySE(1);
    }
    public void ToSettingButton()
    {
        SoundManager.instance.PlaySE(1);
    }
    //-----ここまでボタン関連-----


    //-----ガチャ関連-----

    //ガチャのコルーチン
    IEnumerator Gacha()
    {
        yield return new WaitForSeconds(2.3f);
        //演出の停止
        // gachaMovie.Stop();
        normalGachaMovie.SetActive(false);

        for(int i = 0;i<8;i++)
        {
            pickOneCard(i);
        }
        //セーブ処理
        PlayerPrefsUtility.SaveDict<int,int> ("haveCards",haveCards);

        okButton.SetActive(true);
        gachaCardsPlace.SetActive(true);
    }

    //1枚カードを抽選する
    void pickOneCard(int cardIndex)
    {
        int rareIndex = getRareIndex();//1~4が入る
        int cardID;

        //レア度によって抽選先を分岐
        if(rareIndex == 1)
        {
            //cardID:1001〜1002まで（仕様上MAX値はmax+1に設定）
            cardID = getRandom(1+1000,PlayerManager.instance.rareNumbers[0]+1+1000);
        }
        else if(rareIndex == 2)
        {
            //cardID:2001〜2002まで（仕様上MAX値はmax+1に設定）
            cardID = getRandom(1+2000,PlayerManager.instance.rareNumbers[1]+1+2000);
        }
        else if(rareIndex == 3)
        {
            //cardID:3001〜3002まで（仕様上MAX値はmax+1に設定）
            cardID = getRandom(1+3000,PlayerManager.instance.rareNumbers[2]+1+3000);
        }
        else
        {
            //cardID:4001〜4002まで（仕様上MAX値はmax+1に設定）
            cardID = getRandom(1+4000,PlayerManager.instance.rareNumbers[3]+1+4000);
        }
        CreateCard(cardID,cardIndex);
        addHaveCards(cardID);
        Debug.Log(cardID+":"+haveCards[cardID]);
    }

    //レアリティの抽選
    //重みありのレアリティ抽選(N:50%,R:30%,SR:15%,UR:5%)
    int getRareIndex()
    {
        int rareIndex;
        int randomValue = Random.Range(0,100);
        if(randomValue <= 99 && 95<=randomValue)
        {
            rareIndex = 4;
        }
        else if(randomValue < 95 && 80<=randomValue)
        {
            rareIndex = 3;
        }
        else if(randomValue < 80 && 50<=randomValue)
        {
            rareIndex = 2;
        }
        else
        {
            rareIndex = 1;
        }
        return rareIndex;
    }

    //1~maxまででランダムな整数を返す
    int getRandom(int min,int max)
    {
        return Random.Range(min,max);
    }

    //cardIDからカードを生成
    void CreateCard(int cardID,int cardIndex)
    {
        card[cardIndex] = Instantiate(prefab);
        card[cardIndex].Init(cardID);
        card[cardIndex].transform.SetParent(parent,false);
    }
    public void addHaveCards(int cardID)
    {
        if(haveCards.ContainsKey(cardID))//同じcardIDが存在するときの処理
        {
            haveCards[cardID]++;
        }
        else//同じcardIDが存在しないとき
        {
            haveCards.Add(cardID,1);
        }
    }
    //-----ここまでガチャ関連-----

}
