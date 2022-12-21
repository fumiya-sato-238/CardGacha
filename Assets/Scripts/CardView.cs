using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text rareText;
    [SerializeField] Text nameText;
    [SerializeField] Image iconImage;
    [SerializeField] Image cardPanel;

    public void Show(CardModel cardModel)
    {
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
    }
}
