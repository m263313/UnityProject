using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class WinPopUp : MonoBehaviour
{
    public GameObject winPopUpPrefab;
   public MyButton closeButton;
    public MyButton nextButton;
    public MyButton againButton;
    public MyButton backgroundButton;
    public GameObject crystalRed;
    public GameObject crystalGreen;
    public GameObject crystalBlue;
    public GameObject fruitPanel;
    void Start()
    {
        closeButton.signalOnClick.AddListener(this.onNext);
        backgroundButton.signalOnClick.AddListener(this.onNext);
        againButton.signalOnClick.AddListener(this.onAgain);
        nextButton.signalOnClick.AddListener(this.onNext);
        crystalRed.GetComponent<UI2DSprite>().sprite2D=CrystalController.current.redObj.sprite2D;
        crystalGreen.GetComponent<UI2DSprite>().sprite2D = CrystalController.current.greenObj.sprite2D;
        crystalBlue.GetComponent<UI2DSprite>().sprite2D = CrystalController.current.blueObj.sprite2D;
        fruitPanel.GetComponent<UILabel>().text = FruitController.current.countOnPanel.text;
    }

    

    void onAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        String currLevel = scene.name.Substring(5);
        LevelStat levelInfo;
        string str = PlayerPrefs.GetString(currLevel, null);
        if (str == null)
        {
            levelInfo = new LevelStat();
        }
        else
        levelInfo = JsonUtility.FromJson<LevelStat>(str);
       
     
 
 
      
        Time.timeScale = 1f;
        print(scene.name.Substring(5));

   
        if (!levelInfo.hasCrystals)
            levelInfo.hasCrystals = CrystalController.current.isAll();
        if (!levelInfo.levelPassed)
            levelInfo.levelPassed = true;
        if (!levelInfo.hasAllFruits)
            levelInfo.hasAllFruits = FruitController.current.isAll();
        levelInfo.collectedFruits = FruitController.current.fruitsCollected;
        print(levelInfo.hasAllFruits    );

        str = JsonUtility.ToJson(levelInfo);
        PlayerPrefs.SetString(currLevel, str);
        SceneManager.LoadScene(scene.name);

    }
    void onNext()
    {
        Scene scene = SceneManager.GetActiveScene();
        String currLevel = scene.name.Substring(5);
        string str = PlayerPrefs.GetString(currLevel, null);
        LevelStat levelInfo;
        if (str == null || str.Length==0  )
        {
            levelInfo = new LevelStat();
        }
        else
            levelInfo = JsonUtility.FromJson<LevelStat>(str);


        Time.timeScale = 1f;
        print(scene.name.Substring(5));


        if (!levelInfo.hasCrystals)
            levelInfo.hasCrystals = CrystalController.current.isAll();
        if (!levelInfo.levelPassed)
            levelInfo.levelPassed = true;
        if (!levelInfo.hasAllFruits)
            levelInfo.hasAllFruits = FruitController.current.isAll();
        levelInfo.collectedFruits = FruitController.current.fruitsCollected;
        print(levelInfo.hasAllFruits);

        str = JsonUtility.ToJson(levelInfo);
        PlayerPrefs.SetString(currLevel, str);
        SceneManager.LoadScene("LevelChoice");
        
    }
}
