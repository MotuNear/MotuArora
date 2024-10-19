
using UnityEngine;

public class PlayerPrefsMapProgressManager : IMapProgressManager
{
    private string GetLevelKey(int number)
    {
        return string.Format("Level.{0:000}.StarsCount", number);
    }

    public int LoadLevelStarsCount(int level)
    {   
       {

        }
        if( DatabaseManager.Instance.GetLocalData().data.starsCount.ContainsKey(GetLevelKey(level))){
        return DatabaseManager.Instance.GetLocalData().data.starsCount[GetLevelKey(level)];
        }
        {   LocalData data =  DatabaseManager.Instance.GetLocalData();
            data.data.starsCount.Add(GetLevelKey(level),0);
            return 0;

        }
        
    }

    public void SaveLevelStarsCount(int level, int starsCount)
    {   

        if( DatabaseManager.Instance.GetLocalData().data.starsCount.ContainsKey(GetLevelKey(level))){

             LocalData data = DatabaseManager.Instance.GetLocalData();
        data.data.starsCount[GetLevelKey(level)] = starsCount;
        DatabaseManager.Instance.UpdateData(data);

       
        }
        else{

              LocalData data =  DatabaseManager.Instance.GetLocalData();
            data.data.starsCount.Add(GetLevelKey(level),starsCount);
            DatabaseManager.Instance.UpdateData(data);
        }

       


        
    }

    public void ClearLevelProgress(int level)
    {
        if( DatabaseManager.Instance.GetLocalData().data.starsCount.ContainsKey(GetLevelKey(level))){
            LocalData data = DatabaseManager.Instance.GetLocalData();
            data.data.starsCount[GetLevelKey(level)] = 0;
            DatabaseManager.Instance.UpdateData(data);
        }
        
    }
}
