using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int number;
    public Text label;
    public GameObject lockimage;

    // Use this for initialization
    void Start()
    {   
        
        if (DatabaseManager.Instance.GetLocalData().data.scores["Score" + (number - 1)] > 0)
        {
            lockimage.gameObject.SetActive(false);
            label.text = "" + number;
        }

        int stars = DatabaseManager.Instance.GetLocalData().data.starsCount[string.Format("Level.{0:000}.StarsCount", number)];

        if (stars > 0)
        {
            for (int i = 1; i <= stars; i++)
            {
                transform.Find("Star" + i).gameObject.SetActive(true);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLevel()
    {
        InitScriptName.InitScript.Instance.OnLevelClicked(this, new LevelReachedEventArgs(number));
    }
}
