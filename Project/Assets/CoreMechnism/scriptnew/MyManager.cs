using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyManager : MonoBehaviour
{

    public static MyManager insta;
    public static bool regen = false;

    void Awake()
    {
        if (insta != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            insta = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("Calling");
            if (SceneManager.GetActiveScene().name.Equals("game"))
            {
                Debug.Log(SceneManager.GetActiveScene().name + " Pause");

                if (GameEvent.Instance.GameStatus == GameState.Pause || MenuManager.Instance.MenuPause.activeSelf)
                {
                    MyManager.regen = true;

                    InitScriptName.InitScript.Instance.SpendLife(1);
                    SoundBase.Instance.GetComponent<AudioSource>().PlayOneShot(SoundBase.Instance.click);
                    // if (MenuManager.Instance != null)
                    //    (MenuManager.Instance.Loading).SetActive(true);
                    //SceneManager.LoadScene("map");
                    SceneManager.LoadScene("Splash4");

                }
                else
                {
                    if (GameEvent.Instance.GameStatus != GameState.WaitForPopup && GameEvent.Instance.GameStatus != GameState.PrePlayBanner && GameEvent.Instance.GameStatus != GameState.Tutorial && GameEvent.Instance.GameStatus != GameState.WinBanner && GameEvent.Instance.GameStatus != GameState.WinProccess && GameEvent.Instance.GameStatus != GameState.WinMenu)
                    {
                        GameEvent.Instance.GameStatus = GameState.Pause;
                    }

                }
            }
            else if (MenuManager.Instance != null)
            {

                if (!MenuManager.Instance.ManuSpinner.activeSelf)
                {
                    if (!MenuManager.Instance.ExitMenu.activeSelf)
                    {                        
                        MenuManager.Instance.ExitMenu.SetActive(true);
                    }

                }
                Debug.Log("Quit");
            }
            else
            {
                if (SceneManager.GetActiveScene().name.Equals("menu"))
                {
                    Application.Quit();
                }
            }

            //Application.Quit();
            //GameObject.Find("PauseButton").GetComponent<clickButton>().OnMouseDown();
        }
    }
}
