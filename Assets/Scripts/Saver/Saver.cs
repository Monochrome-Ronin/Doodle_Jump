using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using Unity.VisualScripting;

public class Saver : MonoBehaviour
{
    private static string _filePathForSkinsId;
    public static void SaverIntPrefs(string namePrefs, int data)
    {
        PlayerPrefs.SetInt(namePrefs, data);
    }
    public static int GetIntPrefs(string namePrefs)
    {
        return PlayerPrefs.GetInt(namePrefs);
    }
    public static void SaverStringPrefs(string namePrefs, string data)
    {
        PlayerPrefs.SetString(namePrefs, data);
    }
    public static string GetStringPrefs(string namePrefs)
    {
        return PlayerPrefs.GetString(namePrefs);
    }
    public static void SetArraySkinsId(List<int> id)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePathForSkinsId, FileMode.Create);
        binaryFormatter.Serialize(fileStream, id);
        fileStream.Close();
    }
    public static List<int> GetArraySkinsId()
    {
        List<int> id = new List<int>();
        id.Add(0);
        if (!File.Exists(_filePathForSkinsId)) return id;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePathForSkinsId, FileMode.Open);
        id = (List<int>)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();
        return id;
    }
    private void Awake()
    {
        SetValues();
        InitPlayrPrefs();
    }

    private void SetValues()
    {
        _filePathForSkinsId = Application.persistentDataPath + "/arrayskinsid.gamesave";
    }

    private void InitPlayrPrefs()
    {
        if (!PlayerPrefs.HasKey("Coins")) SaverIntPrefs("Coins", 0);
        if (!PlayerPrefs.HasKey("HighScore")) SaverIntPrefs("HighScore", 0);
        if (!PlayerPrefs.HasKey("LastScore")) SaverIntPrefs("Coins", 0);
        if (!PlayerPrefs.HasKey("MuteSound")) SaverStringPrefs("MuteSound", "false");
        if (!PlayerPrefs.HasKey("MuteVibrate")) SaverStringPrefs("MuteVibrate", "false");
    }
}
