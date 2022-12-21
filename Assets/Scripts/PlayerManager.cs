using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    //シングルトン化する
    public static PlayerManager instance;
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
    string playerName;
    //レアごとに枚数を管理
    public int[] rareNumbers = new int[4];
    //Keyの昇順でソートしながら連想配列を作成
    public SortedDictionary<int,int> haveCards = new SortedDictionary<int,int>();

    void Start()
    {

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
            haveCards.OrderBy((x) => x.Key);//Keyの昇順でソート
        }
    }

}
