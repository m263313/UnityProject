using UnityEngine;
using System.Collections;

public class CoinsController : MonoBehaviour
{
    private int zeroCount = 4;
    public UILabel countOnPanel;
    public static CoinsController current = null;
   public static  int totalCount;
    int count = 0;
    //public List<Co> fruits = new List<Fruit>();
    // Use this for initialization
    void Start()
    {
        totalCount =PlayerPrefs.GetInt("coins",0);
       // totalCount = fruits.Count;
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
        totalCount++;
        updatePanel();

        PlayerPrefs.SetInt("coins", totalCount);
     //   PlayerPrefs.SetInt("coins", totalCount);
        PlayerPrefs.Save();
    }
    public void updatePanel()
    {

        string temp = totalCount.ToString(); ;
        string zeros = "";
        for(int i=temp.Length;i<zeroCount;i++)
        {
            zeros += '0';
        }
        countOnPanel.text = zeros + "" + totalCount;
    }
}
