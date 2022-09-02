using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public static void SaverIntPrefs(string namePrefs, int data)
    {
        PlayerPrefs.SetInt(namePrefs, data);
    }
    public static int GetIntPrefs(string namePrefs)
    {
        return PlayerPrefs.GetInt(namePrefs);
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Coins")) SaverIntPrefs("Coins", 0);
        if (!PlayerPrefs.HasKey("Score")) SaverIntPrefs("Score", 0);
    }
}
