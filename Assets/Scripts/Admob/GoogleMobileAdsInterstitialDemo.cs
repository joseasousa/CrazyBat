using UnityEngine;
using System.Collections;

public class GoogleMobileAdsInterstitialDemo : MonoBehaviour {

	public string PublisherId = "";
   
	void Start()
	{
		GoogleMobileAdsPlugin.CreateInterstitial(PublisherId);
	}

    public void StartBanner() {
        GoogleMobileAdsPlugin.RequestInterstitial(true);
    }

	void OnEnable()
	{
		GoogleMobileAdsPlugin.InterstitialReceivedAd 		 += HandleReceivedAd;
		GoogleMobileAdsPlugin.InterstitialFailedToReceiveAd  += HandleFailedToReceiveAd;
	}
	
	void OnDisable()
	{
		GoogleMobileAdsPlugin.InterstitialReceivedAd 			-= HandleReceivedAd;
		GoogleMobileAdsPlugin.InterstitialFailedToReceiveAd 	-= HandleFailedToReceiveAd;
	}
	
	public void HandleReceivedAd()
	{
		print("HandleReceivedAd event received");
		GoogleMobileAdsPlugin.ShowInterstitial();
	}
	
	public void HandleFailedToReceiveAd(string message)
	{
		print("HandleFailedToReceiveAd event received with message:");
		print(message);
	}
}
