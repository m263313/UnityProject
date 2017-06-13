using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    public GameObject losePopUp;
    public static LivesController current = null;
    public const int maxLives = 3;
    int currentLives = maxLives;
    public List<UI2DSprite> hearts;

    public Sprite full;
    public Sprite empty;
    // Use this for initialization
    void Start()
    {
        setLives(maxLives);
    }

    // Update is called once per frame
    void Update()
    {
        setLives(currentLives);
    }
    public void setLives(int lives)
    {
        for (int i = 0; i < maxLives; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite2D = this.full;
            }
            else
            {
                hearts[i].sprite2D = this.empty;
            }

        }
    }

    private void Awake()
    {
        current = this;
    }
    public void death()
    {
        if (currentLives <= 1)
        {
            //Знайти батьківський елемент
            GameObject parent = UICamera.first.transform.parent.gameObject;
            //Створити Prefab
            GameObject obj = NGUITools.AddChild(parent, losePopUp);

            Time.timeScale = 0.0f;
            // SceneManager.LoadScene("LevelChoice");
        }

        currentLives--;
    }
    public void collectHeart()
        {
        if (currentLives<3)
        {
            currentLives++;
        }

        }

}
