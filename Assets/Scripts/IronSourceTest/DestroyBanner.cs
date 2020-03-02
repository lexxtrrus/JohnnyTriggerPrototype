using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class DestroyBanner : MonoBehaviour
{
    [SerializeField] private Button destroyBannerButton;
    void Reset()
    {
        destroyBannerButton = GetComponent<Button>();
    }

    private void Awake()
    {
        destroyBannerButton.onClick.AddListener(DestroyBannerOnButtonPressed);
    }

    private void DestroyBannerOnButtonPressed()
    {
        Debug.Log("pressed");
        IronSource.Agent.destroyBanner();
    }
}
