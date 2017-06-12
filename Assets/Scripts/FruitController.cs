using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class FruitController : MonoBehaviour
{
    public UILabel countOnPanel;
    public static FruitController current=null;
    int totalCount;
    int count = 0;
    public List<Fruit> fruits =new List<Fruit>() ;
    public List<Fruit> fruitsCollected = new List<Fruit>();
    // Use this for initialization
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        String currLevel = scene.name.Substring(5);
        LevelStat levelInfo=null;
        string str = PlayerPrefs.GetString(currLevel, null);
        if (str != null)
        {
            levelInfo = JsonUtility.FromJson<LevelStat>(str);
        }
        if(levelInfo!=null)
        fruitsCollected = levelInfo.collectedFruits;
        totalCount = fruits.Count;
        updatePanel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        current = this;
    }
    public void increase()
    {
        count++;
        updatePanel();
    }
    public void updatePanel()
    {
        countOnPanel.text = count + "/" + totalCount;
    }
    public bool isAll()
    {
       return count == totalCount;
    }
}
