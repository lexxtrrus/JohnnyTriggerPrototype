using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System;

[RequireComponent(typeof(Button))]
public class FacebookShareButton : MonoBehaviour
{
    [SerializeField] private Button shareToFacebookButton;
    void Reset()
    {
        shareToFacebookButton = GetComponent<Button>();
    }

    private void Awake()
    {
        shareToFacebookButton.onClick.AddListener(ShareSomething);
    }

    private void ShareSomething()
    {
        FB.ShareLink(new Uri("https://developers.facebook.com/"), callback: ShareCallback);
    }

    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }
}
