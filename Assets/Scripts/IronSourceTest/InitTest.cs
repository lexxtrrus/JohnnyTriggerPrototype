using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTest : MonoBehaviour
{
    private IronSource ironSource;

    private void Awake()
    {
        ironSource = IronSource.Agent;
        
        //OnApplicationPause(true);
        ironSource.init("b634229d", IronSourceAdUnits.BANNER, IronSourceAdUnits.REWARDED_VIDEO);
        ironSource.validateIntegration();

        ironSource.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);

        ironSource.displayBanner();

        BannerInfo();
        RewardedVideoInfo();

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnApplicationPause(bool isPaused) 
    {
        ironSource.onApplicationPause(isPaused);
    }

    private void RewardedVideoInfo()
    {
        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
        IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
        IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;
    }

    private void BannerInfo()
    {
        IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
        IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;        
        IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent; 
        IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent; 
        IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
        IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;
    }



    #region BannerInfo
    //Invoked once the banner has loaded
    private void BannerAdLoadedEvent() 
    {

    }

//Invoked when the banner loading process has failed.
//@param description - string - contains information about the failure.
    private void BannerAdLoadFailedEvent (IronSourceError error) 
    {

    }
// Invoked when end user clicks on the banner ad
    private void BannerAdClickedEvent () 
    {
 
    }
//Notifies the presentation of a full screen content following user click
    private void BannerAdScreenPresentedEvent () 
    {

    }
//Notifies the presented screen has been dismissed
    private void BannerAdScreenDismissedEvent() 
    {

    }
//Invoked when the user leaves the app
    private void BannerAdLeftApplicationEvent() 
    {

    }

    #endregion

    #region VideoInfo

    //Invoked when the RewardedVideo ad view has opened.
    //Your Activity will lose focus. Please avoid performing heavy 
    //tasks till the video ad will be closed.
    void RewardedVideoAdOpenedEvent()
    {

    }
    //Invoked when the RewardedVideo ad view is about to be closed.
    //Your activity will now regain its focus.
    void RewardedVideoAdClosedEvent()
    {
        ShowRewardedVideo.OnVideoRewardClosed?.Invoke();
    }
    //Invoked when there is a change in the ad availability status.
    //@param - available - value will change to true when rewarded videos are available. 
    //You can then show the video by calling showRewardedVideo().
    //Value will change to false when no videos are available.
    void RewardedVideoAvailabilityChangedEvent(bool available)
    {
        //Change the in-app 'Traffic Driver' state according to availability.
        bool rewardedVideoAvailability = available;
    }
    //  Note: the events below are not available for all supported rewarded video 
    //   ad networks. Check which events are available per ad network you choose 
    //   to include in your build.
    //   We recommend only using events which register to ALL ad networks you 
    //   include in your build.
    //Invoked when the video ad starts playing.
    void RewardedVideoAdStartedEvent()
    {
    }
    //Invoked when the video ad finishes playing.
    void RewardedVideoAdEndedEvent()
    {

    }
    //Invoked when the user completed the video and should be rewarded. 
    //If using server-to-server callbacks you may ignore this events and wait for the callback from the  ironSource server.
    //
    //@param - placement - placement object which contains the reward data
    //
    void RewardedVideoAdRewardedEvent(IronSourcePlacement placement)
    {

    }
    //Invoked when the Rewarded Video failed to show
    //@param description - string - contains information about the failure.
    void RewardedVideoAdShowFailedEvent(IronSourceError error)
    {

    }

    #endregion
}
