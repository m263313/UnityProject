using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrystalController : MonoBehaviour
{


    //   public List<UI2DSprite> crystals;
    public static CrystalController current = null;
    public UI2DSprite greenObj;
    public UI2DSprite redObj;
    public UI2DSprite blueObj;
    public  enum Crystals
    {
        green,
        red,
        blue
    }
   public static Dictionary<Crystals, Sprite> mapCrystals;
    public static Dictionary<Crystals, UI2DSprite>mapObjects;
    public Sprite green;
    public Sprite red;
    public Sprite blue;
   // public Sprite empty;
    // Use this for initialization
    void Start()
    {
        mapCrystals = new Dictionary<Crystals, Sprite>();
            mapCrystals.Add(Crystals.green,green);
        mapCrystals.Add(Crystals.blue, blue);
        mapCrystals.Add(Crystals.red, red);
        mapObjects = new Dictionary<Crystals, UI2DSprite>();
        mapObjects.Add(Crystals.green, greenObj);
        mapObjects.Add(Crystals.blue, blueObj);
        mapObjects.Add(Crystals.red, redObj);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        current = this;
    }
    public void setCrystal(Crystal type)
    {
        mapObjects[type.type].sprite2D = mapCrystals[type.type];
        
    }
}
