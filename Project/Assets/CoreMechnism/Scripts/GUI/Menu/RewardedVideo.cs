using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if APPODEAL
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
#endif

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
using UnityEngine.SceneManagement;
using InitScriptName;

#if GOOGLE_MOBILE_ADS
using System;
#endif
public class RewardedVideo : MonoBehaviour//, IRewardedVideoAdListener
{

    string rewardedVideoZone;
    // Use this for initialization
    void OnEnable()
    {
        if (GetRewardedAdsReady())
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
#if APPODEAL
		
        Appodeal.setRewardedVideoCallbacks(this);
#endif
    }

    public void GetCoins(int addCoins)
    {
        RewardIcon reward = MenuManager.Instance.RewardPopup.GetComponent<RewardIcon>();
        reward.SetIconSprite(0);
        reward.gameObject.SetActive(true);
        InitScript.Instance.AddGems(addCoins);
        MenuManager.Instance.MenuCurrencyShop.GetComponent<AnimationManager>().CloseMenu();
    }

    public void GetLifes()
    {
        RewardIcon reward = MenuManager.Instance.RewardPopup.GetComponent<RewardIcon>();
        reward.SetIconSprite(1);
        reward.gameObject.SetActive(true);
        InitScript.Instance.RestoreLifes();
        MenuManager.Instance.MenuLifeShop.GetComponent<AnimationManager>().CloseMenu();

    }


    public void ContinuePlay()
    {
        MenuManager.Instance.PreFailedBanner.GetComponent<AnimationManager>().GoOnFailed();
    }

    public void ShowRewardedAds(int rewardType)
    {
       
    }

    void CheckRewardedAds()
    {

        //		RewardIcon reward = null;
        //		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("map"))//TODO: set reward window to Menu manager
        //			reward = GameObject.Find ("Canvas").transform.Find ("Reward").GetComponent<RewardIcon> ();
        //		if (currentReward == RewardedAdsType.GetGems) {
        //			reward.SetIconSprite (0);
        //
        //			reward.gameObject.SetActive (true);
        //			InitScript.Instance.AddGems (LevelEditorBase.THIS.rewardedGems);
        //			GameObject.Find ("CanvasMenu").transform.Find ("GemsShop").GetComponent<AnimationManager> ().CloseMenu ();
        //		} else if (currentReward == RewardedAdsType.GetLifes) {
        //			reward.SetIconSprite (1);
        //			reward.gameObject.SetActive (true);
        //			InitScript.Instance.RestoreLifes ();
        //			GameObject.Find ("Canvas").transform.Find ("LiveShop").GetComponent<AnimationManager> ().CloseMenu ();
        //		} else if (currentReward == RewardedAdsType.GetGoOn) {
        //			GameObject.Find ("CanvasMenu").transform.Find ("PreFailedBanner").GetComponent<AnimationManager> ().GoOnFailed ();
        //		}

    }

    public bool GetRewardedAdsReady()
    {

      

        return false;
    }

}

