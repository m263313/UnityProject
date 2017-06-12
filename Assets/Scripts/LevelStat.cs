﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelStat  {

    public static LevelStat stats;
        public bool hasCrystals = false;
        public bool hasAllFruits = false;
        public bool levelPassed = false;
        public List<Fruit> collectedFruits = new List<Fruit>();
     
  

}
