using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowRewardedVideo : MonoBehaviour
{
    [SerializeField] private GameObject[] _coinsImages;
    [SerializeField] private Button _coinX2button;

    public static Action OnShowRewardedButtonPressed;
    public static Action OnVideoRewardClosed;
    private void OnEnable()
    {
        _coinX2button.onClick.AddListener(RewardedVideoButtonPressed);

        OnShowRewardedButtonPressed += ChanglePanelLogic;
        OnVideoRewardClosed += RewardedVideoClosed;
    }

    private void OnDisable() 
    {
        OnShowRewardedButtonPressed -= ChanglePanelLogic;
        OnVideoRewardClosed -= RewardedVideoClosed;
    }
    private void RewardedVideoButtonPressed()
    {
        IronSource.Agent.showRewardedVideo();
    }

    private void RewardedVideoClosed()
    {
        StartCoroutine(MagicAfterSecond());
    }

    private IEnumerator MagicAfterSecond()
    {
        yield return new WaitForSeconds(1f);
        OnShowRewardedButtonPressed?.Invoke();
    }

    public void ChanglePanelLogic()
    {
        _coinsImages[0].SetActive(true);
        _coinsImages[1].SetActive(false);
    }


}
