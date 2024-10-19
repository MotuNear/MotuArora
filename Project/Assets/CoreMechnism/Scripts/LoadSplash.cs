using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSplash : MonoBehaviour
{

    public float timetoload = 6f;
    public string sceneName;

    public Text noteTxt;

    void Start()
    {
        //PlayerPrefs.DeleteAll ();

        //Application.targetFrameRate = 56;




        if (noteTxt) noteTxt.text = "";

        StartCoroutine(WaitAndPrint(0.1f));

        // AdsManager.instance.ShowRectAdsAdmob();


    }

    IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSecondsRealtime(waitTime);



        SceneManager.LoadSceneAsync(sceneName);
    }
}
