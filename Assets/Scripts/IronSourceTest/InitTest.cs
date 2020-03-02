using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InitTest : MonoBehaviour
{
    private IronSource ironSource;

    private void Awake()
    {
        ironSource = IronSource.Agent;
        
        //OnApplicationPause(true);
        ironSource.init("b634229d", IronSourceAdUnits.BANNER);
        ironSource.validateIntegration();

        ironSource.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);

        ironSource.displayBanner();

        BannerInfo();       

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnApplicationPause(bool isPaused) 
    {
        ironSource.onApplicationPause(isPaused);
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
}
