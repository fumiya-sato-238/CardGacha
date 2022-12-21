using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel
{
    public int cardID;
    public int rare;
    public string name;
    public Sprite icon; //画像
    public string descriptionText;

    //card1を生成
    //コンストラクタ
    public CardModel(int cardID)
    {
        this.cardID = cardID;
        CardEntity cardEntity = Resources.Load<CardEntity>("Entities/Cards/"+cardID+"_Monster");
        //パスに注意
        // CardEntity cardEntity = Resources.Load<CardEntity>("Entities/"+cardID);
        rare = cardEntity.rare;
        name = cardEntity.name;
        icon = cardEntity.icon;
        descriptionText = cardEntity.descriptionText;
    }
}
