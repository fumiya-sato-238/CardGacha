//PlayerPrefsにDictionary型を保存できるようにするスクリプト

//  PlayerPrefsUtility.cs
//  http://kan-kikuchi.hatenablog.com/entry/PlayerPrefsUtility
//
//  Created by kan kikuchi on 2015.10.22.

using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

/// <summary>
/// PlayerPrefsに関する便利クラス
/// </summary>
public static class PlayerPrefsUtility {

    //=================================================================================
    //保存
    //=================================================================================

    /// <summary>
    /// リストを保存
    /// </summary>
    public static void SaveList<T>(string key , List<T> value){
        string serizlizedList = Serialize<List<T>> (value);
        PlayerPrefs.SetString (key, serizlizedList);
    }

    /// <summary>
    /// ディクショナリーを保存
    /// </summary>
    public static void SaveDict<Key, Value>(string key , SortedDictionary<Key, Value> value){
        string serizlizedDict = Serialize<SortedDictionary<Key, Value>> (value);
        PlayerPrefs.SetString (key, serizlizedDict);
    }

    //=================================================================================
    //読み込み
    //=================================================================================

    /// <summary>
    /// リストを読み込み
    /// </summary>
    public static List<T> LoadList<T> (string key){
        //keyがある時だけ読み込む
        if (PlayerPrefs.HasKey (key)) {
            string serizlizedList = PlayerPrefs.GetString (key);
            return Deserialize<List<T>> (serizlizedList);
        }

        return new List<T> ();
    }

    /// <summary>
    /// ディクショナリーを読み込み
    /// </summary>
    public static SortedDictionary<Key, Value> LoadDict<Key, Value> (string key){
        //keyがある時だけ読み込む
        if (PlayerPrefs.HasKey (key)) {
            string serizlizedDict = PlayerPrefs.GetString (key);
            return Deserialize<SortedDictionary<Key, Value>> (serizlizedDict);
        }

        return new SortedDictionary<Key, Value> ();
    }

    //=================================================================================
    //シリアライズ、デシリアライズ
    //=================================================================================

    private static string Serialize<T> (T obj){
        BinaryFormatter binaryFormatter = new BinaryFormatter ();
        MemoryStream    memoryStream    = new MemoryStream ();
        binaryFormatter.Serialize (memoryStream , obj);
        return Convert.ToBase64String (memoryStream   .GetBuffer ());
    }

    private static T Deserialize<T> (string str){
        BinaryFormatter binaryFormatter = new BinaryFormatter ();
        MemoryStream    memoryStream    = new MemoryStream (Convert.FromBase64String (str));
        return (T)binaryFormatter.Deserialize (memoryStream);
    }
}
