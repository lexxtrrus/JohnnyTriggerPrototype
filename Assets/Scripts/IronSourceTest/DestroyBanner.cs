using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DestroyBanner : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Reset() 
    {
        button = GetComponent<Button>();
    }
    void Awake()
    {
        button.onClick.AddListener(DestroyBannerAndShowVideo);
    }

    private void DestroyBannerAndShowVideo()
    {
        IronSource.Agent.hideBanner();
        IronSource.Agent.showRewardedVideo();
    }
}
