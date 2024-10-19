
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class Spin : MonoBehaviour
{

    [Header("RigidBoady Rotation")]
    public float MinTorque;
    public float MaxTourque;
    public bool AllowSpin;
    public bool Stable;
    public GameObject Head;
    public LayerMask mask;
    Rigidbody2D Rd;
    public Text Score;
    public Text note;
    public Button SpinButton;
    Text spintext;
    private BoxCollider2D[] Points;
    AudioSource ad;
    GameObject old;
    [Header("AudioClip Clips")]
    public AudioClip TickSound;
    public AudioClip Win;
    public AudioClip Loss;

    //private RewardBasedVideoAd rewardBasedVideo;
    public string rewAnd, rewiOS;

    void Awake()
    {
        transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)));
        spintext = SpinButton.GetComponentInChildren<Text>();
        spintext.text = "SPIN";
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();

#if UNITY_ANDROID
		string appId = rewAnd;
#elif UNITY_IPHONE
        string appId = rewiOS;
#else
		string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        //MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
       // this.rewardBasedVideo = RewardBasedVideoAd.Instance;


        // Called when the user should be rewarded for watching a video.
      //  rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
       // rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

       // RequestRewardBasedVideo();
    }

   /* private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
		string appId = rewAnd;
#elif UNITY_IPHONE
        string appId = rewiOS;
#else
		string appId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, appId);
    }*/

    void OnEnable()
    {
        Debug.Log("Test");
        if (!GetspinPerDay())
        {
            AllowSpin = false;
            Score.text = "1 spin per day";
            SpinButton.interactable = true;
            spintext.text = "Watch Video Ad";
            note.text = "Watch video ad for spinner";
            return;
        }
        else
            SetupSpinner();
    }

    void SetupSpinner()
    {
        Debug.Log("Allow spin");
        AllowSpin = true;
        PlayerPrefs.SetString("LastDay", System.DateTime.Now.ToString());
        SpinButton.interactable = true;
        ad = GetComponent<AudioSource>();
        Points = GetComponentsInChildren<BoxCollider2D>();
        Score.text = "";
        note.text = "1 spin per day";
        Rd = GetComponent<Rigidbody2D>();
        Stable = true;
        Debug.Log("Start Speed : " + Rd.angularVelocity);
        old = Points[0].gameObject;
    }

    bool GetspinPerDay()
    {
        if (PlayerPrefs.GetString("LastDay") == "")
            return true;
        System.DateTime lastdatetime = System.DateTime.Parse(PlayerPrefs.GetString("LastDay"));
        if (System.DateTime.Now.Subtract(lastdatetime).Days > 0f)
            return true;
        else
            return false;
    }

    void Update()
    {

        if (!Stable && AllowSpin)
        {
            PlaySound();
            if (Rd.angularVelocity >= -20f)
            {
                Stable = true;
                AllowSpin = false; // Disable Spin
                Rd.freezeRotation = true;
                CheckScore();
            }
        }

    }

    void PlaySound()
    {
        RaycastHit2D hit;
        Vector2 orgin = new Vector2(Head.transform.position.x, Head.transform.position.y);
        hit = Physics2D.Raycast(orgin, Vector2.up, 1000f, mask);
        Debug.DrawRay(Head.transform.position, Vector3.up, Color.yellow);

        if (hit.collider != null)
        {

            Debug.DrawRay(Head.transform.position, Vector3.up, Color.red);
            if (hit.transform.name != old.name)
            {
                old = hit.transform.gameObject;
                Debug.Log("Colide With :" + hit.transform.name);
                if (!ad.isPlaying)
                    ad.PlayOneShot(TickSound, 1);
            }
        }

    }

    void CheckScore()
    {
        RaycastHit2D hit;
        Vector2 orgin = new Vector2(Head.transform.position.x, Head.transform.position.y);
        hit = Physics2D.Raycast(orgin, Vector2.up, 1000f, mask);

        if (hit.collider != null)
        {

            Debug.DrawRay(Head.transform.position, Vector3.up, Color.green);
            Debug.Log("Collider Name " + hit.collider.name);
            for (int i = 0; i < Points.Length; i++)
            {
                if (hit.transform.name == Points[i].name)
                {
                    Debug.Log("Hit Score :" + Points[i].name);
                    Score.text = "WoN !! " + Points[i].name + " Coins ";
                    //PlayerPrefs.SetFloat ("bitcoin", PlayerPrefs.GetFloat ("bitcoin") + int.Parse(Points [i].name));
                    InitScriptName.InitScript.Instance.AddGems(int.Parse(Points[i].name));
                    //MainCanvas.instance.Bitcoin.text = MainCanvas.instance.BitcoinConvert(PlayerPrefs.GetFloat ("bitcoin"));

                    ad.PlayOneShot(Win, 1);
                    break;
                }
            }
        }
        else
        {
            Score.text = "Opps !! Come Next Day ";
            ad.PlayOneShot(Loss, 1);
        }
        SpinButton.interactable = true;
        //spintext.color = Color.white;
        spintext.text = "Watch Video Ad";
        note.text = "Watch video ad for spinner";
    }

    public void SpinRing()
    {
        if (AllowSpin)
        {
            //spintext.color = Color.black;
            spintext.text = "Spinning";
            SpinButton.interactable = false;
            Rd.freezeRotation = false;
            Stable = false;
            float Aplytorque = UnityEngine.Random.Range(MinTorque, MaxTourque);
            Rd.AddTorque(-Aplytorque, ForceMode2D.Impulse);
           
        }
        else
        {
            //ShowVideoAd ();
            ShowRewardBasedVideo();
        }
    }

    public void ShowVideoAd()
    {
        /*if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;

            Advertisement.Show("rewardedVideo", options);
        }
        else
        {
            MenuManager.Instance.SpinnerMsg.SetActive(true);
            MenuManager.Instance.spinnerTextMsg.text = "No internet\nor\nLoading video";

        }*/
    }

    public void ShowRewardBasedVideo()
    {
       
    }

   /* void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            spintext.text = "SPIN";
            AllowSpin = true;
            Score.text = "";
            note.text = "";
            SetupSpinner();
            MenuManager.Instance.SpinnerMsg.SetActive(true);
            MenuManager.Instance.spinnerTextMsg.text = "Spin now\nTry your luck";
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
*/

    //== Video ad events ====//
  

    public void HandleRewardBasedVideoRewarded()
    {
      
        spintext.text = "SPIN";
        AllowSpin = true;
        Score.text = "";
        note.text = "";
        SetupSpinner();
        MenuManager.Instance.SpinnerMsg.SetActive(true);
        MenuManager.Instance.spinnerTextMsg.text = "Spin now\nTry your luck";
    }


}
