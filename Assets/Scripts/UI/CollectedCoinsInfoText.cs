using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCoinsInfoText : MonoBehaviour
{
    [SerializeField] private Text textCountMoney;
    [SerializeField] private MoneyCounter moneyCounter;

    private void OnEnable() 
    {
        textCountMoney.text = $"COLLECTED: {moneyCounter.EarnedMoney.ToString()}";
        ShowRewardedVideo.OnShowRewardedButtonPressed += SetIncomeAfterRewardedVideo;
    }

    private void OnDisable() 
    {
        ShowRewardedVideo.OnShowRewardedButtonPressed -= SetIncomeAfterRewardedVideo;
    }

    private void SetIncomeAfterRewardedVideo()
    {
        textCountMoney.text = $"COLLECTED: {moneyCounter.DoubleEarnedMoney.ToString()}";
    }
}
