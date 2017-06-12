using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public String nameLevel;
	void Start () {
        if (nameLevel == null)
            nameLevel = "Level1";

        
        String currLevel = nameLevel.Substring(5);

        if (Convert.ToInt32(currLevel) > 1)
        {

            LevelStat levelInfo;
            string str = PlayerPrefs.GetString((Convert.ToInt32(currLevel) - 1) + "", null);
            if (str == null || str.Length==0)
            {
                levelInfo = new LevelStat();
            }
            else
                levelInfo = JsonUtility.FromJson<LevelStat>(str);
            if (!levelInfo.levelPassed)
            {
               
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        //Намагаємося отримати компонент кролика
        HeroRabbit rabit = collider.GetComponent<HeroRabbit>();
        //Впасти міг не тільки кролик
        if (rabit != null)
        {
            SceneManager.LoadScene(nameLevel);

        }
    }

}
