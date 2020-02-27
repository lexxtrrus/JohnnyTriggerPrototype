using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TapForStartCheck : MonoBehaviour
{
    public static Action OnTapForStartAction;
    [SerializeField] private Text tapStartText;

    private void Reset()
    {
        tapStartText = GetComponent<Text>();
    }
    private void Awake()
    {
        OnTapForStartAction += HideStartTapText;
    }

    private void OnDisable()
    {
        OnTapForStartAction -= HideStartTapText;
    }

    private void HideStartTapText()
    {
        tapStartText.gameObject.SetActive(false);
}
}
