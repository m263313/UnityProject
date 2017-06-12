using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class FullSaver : MonoBehaviour
{
    public static List<LevelStat> levelsInfo=new List<LevelStat>();
     
    // Use this for initialization
    void Start()
    {
        load();
        if (levelsInfo.Count == 0)
            for (int i = 0; i < 2; i++)
            {
                levelsInfo.Add(new LevelStat());
            }
        
                for (int i = 0; i < 2; i++)
        {
            if (levelsInfo[i] == null)
                levelsInfo[i] = new LevelStat();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void saveToDisk()
    {
        string str = JsonUtility.ToJson(levelsInfo);
        PlayerPrefs.SetString("level_stats", str);
        
    }
   static void load()
    {
        string str = PlayerPrefs.GetString("level_stats", null);
        levelsInfo = JsonUtility.FromJson<List<LevelStat>>(str);
        if (levelsInfo==null)
        {
            levelsInfo = new List<LevelStat>();
        }
    }
}
