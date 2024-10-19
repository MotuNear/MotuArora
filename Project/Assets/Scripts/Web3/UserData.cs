using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            //LoadData();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //LoadData();
    }

    public Data data;

    public static event Action<bool> OnUserDataChanged;

    public int totalLevels;
    internal void LoadData()
    {
        data = DatabaseManager.Instance.GetLocalData().data;
        if(data == null)
        {
            data = new Data();
            data.starsCount = new Dictionary<string, int>();
             data.scores = new Dictionary<string, int>();
           
            SaveNewData();
        }
       

        OnUserDataChanged?.Invoke(false);
    }

    public void SaveNewData()
    {
        //PlayerPrefs.SetString("data", JsonConvert.SerializeObject(data));
        OnUserDataChanged?.Invoke(true);
    }

    internal void SetCoinsTexts()
    {
        OnUserDataChanged?.Invoke(false);
    }
}
[System.Serializable]
public class Data
{
    
    public Dictionary<string,int> starsCount;   
     public Dictionary<string,int> scores;   
    
    
    
    public int Gems =100;
    public int Lifes =5;
    

    
     public int OpenLevel =1;

    public Data() {
        
        Gems =100;
        Lifes =5;
    

        OpenLevel =1;
        starsCount = new Dictionary<string, int>();
        scores = new Dictionary<string, int>();
       
    
    }

   
}
