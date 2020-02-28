using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private Text moneyCount;

    public static Action<int> OnBulletTouched;

    private void Awake()
    {
        SetCountOnScreen();
        OnBulletTouched += AddGold;
    }

    private void OnDisable()
    {
        OnBulletTouched -= AddGold;
    }
    private void AddGold(int value)
    {
        Profile.Money += value;
        Profile.Save(player: false);
        SetCountOnScreen();
    }

    private void SetCountOnScreen()
    {
        moneyCount.text = $"MONEY: {Profile.Money.ToString()}";
    }
}
