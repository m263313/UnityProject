﻿public class Fruit : Collectable {

	protected override void OnRabitHit (HeroRabbit rabit)
	{

		this.CollectedHide ();
        increase();
	}
    void increase()
    {
        FruitController.current.increase();
    }
}