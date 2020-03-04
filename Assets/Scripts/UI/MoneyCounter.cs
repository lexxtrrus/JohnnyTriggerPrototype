using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private Vector2 _beginPoint;
    [SerializeField] private Vector2 _middlePoint;
    [SerializeField] private Vector2 _endPoint;
    [SerializeField] private GameObject _coinSprite;

    [SerializeField] private RectTransform _parent;

    [SerializeField] private Text moneyCount;    
    [SerializeField] private int levelEarnedMoney = 0;
    public int EarnedMoney => levelEarnedMoney;
    public int DoubleEarnedMoney => levelEarnedMoney * 2;
    public static Action<int> OnBulletTouched;

    private void Awake()
    {
        SetCountOnScreen();
        OnBulletTouched += AddGold;
        ShowRewardedVideo.OnShowRewardedButtonPressed += LevelFinalSaveMoney;
        FinalReached.OnFinalPanelShowed += LevelFinalSaveMoney;
    }

    private void OnDisable()
    {
        OnBulletTouched -= AddGold;
        ShowRewardedVideo.OnShowRewardedButtonPressed -= LevelFinalSaveMoney;
        FinalReached.OnFinalPanelShowed -= LevelFinalSaveMoney;
    }
    private void AddGold(int value)
    {
        levelEarnedMoney += value;
    }

    private void SetCountOnScreen()
    {
        moneyCount.text = $"{Profile.Money.ToString()}";
    }

    private void LevelFinalSaveMoney()
    {
        Debug.Log(Time.timeScale);
        StartCoroutine(SaveMoney());
        StartCoroutine(CoinPrefabMovement());
    }

    public void LevelEarnedMoneyToNull()
    {
        levelEarnedMoney = 0;
    }
    private IEnumerator CoinPrefabMovement()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject coin = Instantiate(_coinSprite) as GameObject;
        coin.transform.SetParent(_parent);
        coin.transform.localPosition = Vector3.zero;

        var startTime = Time.time;
        var timer = startTime + 2f;

        var duration = 2f;
        Vector2 pos1, pos2, pos3;

        while(Time.time < timer)
        {
            float t = (Time.time - startTime)/duration;

            pos1 = _beginPoint + (_middlePoint - _beginPoint) * t;
            pos2 = _middlePoint + (_endPoint - _middlePoint) * t;
            pos3 = pos1 + (pos2 - pos1) * t;

            coin.transform.localPosition = pos3;
            yield return null;
        }
        Destroy(coin);
    }

    private IEnumerator SaveMoney()
    {
        Profile.Money += levelEarnedMoney;
        Profile.Save(player: false);
        yield return new WaitForSeconds(2f);
        SetCountOnScreen();
    }
}
