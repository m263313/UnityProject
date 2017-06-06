using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitController : MonoBehaviour
{
    public UILabel countOnPanel;
    public static FruitController current=null;
    int totalCount;
    int count = 0;
    public List<Fruit> fruits =new List<Fruit>() ;
    // Use this for initialization
    void Start()
    {
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
}
