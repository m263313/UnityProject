using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChoiceDoor : MonoBehaviour
{
   public string level;
   public GameObject winLabel;
    public GameObject allCrystals;
    public GameObject allFruits;
    public Sprite getFruits;
    public Sprite getCrystals;
    public Sprite getWin;
    // Use this for initialization
    void Start()
    {
       
        LevelStat levelInfo;
        string str = PlayerPrefs.GetString(level, null);
        if (str == null || str.Length==0)
        {
            levelInfo = new LevelStat();
        }
        else
            levelInfo = JsonUtility.FromJson<LevelStat>(str);
        if (levelInfo.hasAllFruits)
            allFruits.GetComponent<SpriteRenderer>().sprite = getFruits;
        if (levelInfo.hasCrystals)
            allCrystals.GetComponent<SpriteRenderer>().sprite = getCrystals;
        if (levelInfo.levelPassed)
            winLabel.GetComponent<SpriteRenderer>().sprite = getWin;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
