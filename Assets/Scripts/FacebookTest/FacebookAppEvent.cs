using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;

public class FacebookAppEvent : MonoBehaviour
{
    public static Action OnFinalReached;

    private Dictionary<string, object> levels = new Dictionary<string, object>();

    private void Awake()
    {
        levels[AppEventParameterName.ContentID] = "lefel_1";
        levels[AppEventParameterName.Description] = "Complete this level";
        levels[AppEventParameterName.Success] = "LevelCompleted";

        OnFinalReached += ShowSomeAppEvent;
    }

    private void OnDisable()
    {
        OnFinalReached -= ShowSomeAppEvent;
    }

    private void ShowSomeAppEvent()
    {
        FB.LogAppEvent(AppEventName.AchievedLevel, parameters: levels);
    }
}
