﻿public class Coin : Collectable {
	protected override void OnRabitHit (HeroRabbit rabit)
	{
	 
		this.CollectedHide ();
	}
}