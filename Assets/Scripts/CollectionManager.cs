using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
    //Collection用のプレファブを読み込む
    [SerializeField] CollectionCardController prefab;
    [SerializeField] Transform parent;//カードを生成する場所
    [SerializeField] Text possessionText;
    SortedDictionary<int,int> haveCards;

    void Start()
    {
        //PlayerPrefsから所持カードをロード
        haveCards = PlayerPrefsUtility.LoadDict<int,int>("haveCards");

        SoundManager.instance.PlayBGM("Collection");
        //所持率の更新
        updatePossessionText();
        //HaveCardに要素がある時と無いときで処理を変える（NullPointException対策）
        if(haveCards.Count == 0)
        {
            //HaveCardに要素が無いときの処理
        }
        else
        {
            //HaveCardに要素があるときの処理
            CollectionCardController[] card = new CollectionCardController[haveCards.Count];//生成したカードを格納して操作できる
            int i = 0;

            foreach(var haveCard in haveCards)
            {
                CreateCard(haveCard.Key,i);
                i++;
            }

            //cardIDからカードを生成
            void CreateCard(int cardID,int cardIndex)
            {
                card[cardIndex] = Instantiate(prefab);
                card[cardIndex].Init(cardID);
                card[cardIndex].transform.SetParent(parent,false);
            }
        }
    }
    //-----所持数を管理-----
    void updatePossessionText()
    {
        int allCardsNumber = 0;
        foreach(int number in PlayerManager.instance.rareNumbers)
        {
            allCardsNumber += number;
        }
        possessionText.text = "所持率:"+haveCards.Count*100/allCardsNumber+"%";
    }
    //-----ここまで所持数-----

    //-----ボタン関連-----
    public void OnToSceneTransitionButton()
    {
        SoundManager.instance.PlaySE(1);
    }
    //-----ここまでボタン関連-----
}
