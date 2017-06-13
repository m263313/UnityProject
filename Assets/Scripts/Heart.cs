using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectable {

    protected override void OnRabitHit(HeroRabbit rabit)
    {
       

        this.CollectedHide();
        LivesController.current.collectHeart();
    }

}
