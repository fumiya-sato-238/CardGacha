using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailCardManager : MonoBehaviour
{
    //カードの詳細画面の管理・表示を行う（Viewを使わない）
    [SerializeField] GameObject prefab;
    DetailCardView view;
    CardModel model;

    private void Awake()
    {
        view = GetComponent<DetailCardView>();
    }

    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }

    //-----ボタン関連-----
    public void OnOkButton()
    {
        Destroy(prefab);
    }
    //-----ここまでボタン関連-----
}
