using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    //テキストを点滅させる
    [SerializeField] Text blinkText;
    public float speed = 1.0f;
    private float time;

    void Update()
    {
        blinkText.color = GetAlphaColor(blinkText.color);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);

        return color;
    }
}
