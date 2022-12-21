using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CollectionCardView : MonoBehaviour
{
    [SerializeField] Text rareText;
    [SerializeField] Text nameText;
    [SerializeField] Image iconImage;
    [SerializeField] Image cardPanel;
    [SerializeField] Text cardNumberText;//所持枚数
    SortedDictionary<int,int> haveCards;

    public void Show(CardModel cardModel,int cardID)
    {
        haveCards = PlayerPrefsUtility.LoadDict<int,int>("haveCards");
        int rarelity = cardModel.rare;
        if(rarelity ==4)
        {
            cardPanel.sprite = Resources.Load<Sprite>("Images/CardBase/URCardBase");
        }
        else if(rarelity == 3)
        {
            cardPanel.sprite = Resources.Load<Sprite>("Images/CardBase/GoldCardBase");
        }
        else if(rarelity == 2)
        {
            cardPanel.sprite = Resources.Load<Sprite>("Images/CardBase/SilverCardBase");
        }
        else if(rarelity == 1)
        {
            cardPanel.sprite = Resources.Load<Sprite>("Images/CardBase/BronzeCardBase");
        }
        nameText.text = cardModel.name;
        iconImage.sprite = cardModel.icon;
        cardNumberText.text = string.Format("×{0}",haveCards[cardID]);
    }
}
