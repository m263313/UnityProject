using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelStat : MonoBehaviour {

    public static LevelStat stats;
        public bool hasCrystals = false;
        public bool hasAllFruits = false;
        public bool levelPassed = false;
        public List<int> collectedFruits = new List<int>();
     
    public void Save()
    {
        string str = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("stats", str);
    }
    public void read()
    {
        string str = PlayerPrefs.GetString("stats", null);
        stats = JsonUtility.FromJson<LevelStat>(str);
        if (!stats==null)
        {   
            stats = new LevelStat();
        }
    }
}
