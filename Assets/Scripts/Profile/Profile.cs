using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Profile : MonoBehaviour
{
    [System.Serializable]
    private class MainData
    {
        //public List<float> levelsProgress = new List<float>(); 
        public int money = 0;
    }

    private class PlayerData
    {
        //public WeaponData currentWeapon; //а можно ли засунуть в PlayerPrefs ScriptableObject
    }

    private static MainData mainData;
    private static PlayerData playerData;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CheckData()
    {
        SetMainData();
        SetPlayerData();
    }

    private static void SetMainData()
    {
        if (mainData != null) return;

        mainData = GetData<MainData>("MainData");
    }

    private static void SetPlayerData()
    {
        if (playerData != null) return;

        playerData = GetData<PlayerData>("PlayerData");
    }

    private static T GetData<T>(string key) where T: new()
    {
        if(PlayerPrefs.HasKey(key))
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }

        var data = new T();
        PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
        return data;
    }

    public static void Save(bool main = true, bool player = true)
    {
        if (main)
        {
            PlayerPrefs.SetString("MainData", JsonUtility.ToJson(mainData));
        }

        if (player)
        {
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(mainData));
        }
    }

    public static int Money
    {
        get => mainData.money;
        set
        {
            mainData.money = value;
            if (mainData.money < 0)
            {
                mainData.money = 0;
            }

            Save(player: false);
        }
    }
}

