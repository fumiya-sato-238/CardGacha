using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCardController : MonoBehaviour
{
    CollectionCardView view;//コレクション用のviewを読み込む
    CardModel model;
    int thisCardID;
    [SerializeField] DetailCardManager prefab;

    private void Awake()
    {
        view = GetComponent<CollectionCardView>();
    }

    public void Init(int cardID)
    {
        thisCardID = cardID;
        model = new CardModel(cardID);
        view.Show(model,cardID);
    }

    //cardがタップされた時の処理
    public void TapThisCard()
    {
        DetailCardManager detailCardManager = Instantiate(prefab);
        detailCardManager.Init(thisCardID);
        Debug.Log("カードがタップされた");
    }
}
