using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]
public class CardEntity : ScriptableObject
{
    //rareを数字で管理
    //1:N 2:R 3:SR 4:UR
    public int rare;
    public new string name;
    public Sprite icon; //画像
    [Multiline(5)] public string descriptionText;
}
