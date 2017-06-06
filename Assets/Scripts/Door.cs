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
