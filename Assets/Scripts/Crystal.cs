public class Crystal : Collectable {
	protected override void OnRabitHit (HeroRabbit rabit)
	{

		this.CollectedHide ();
	}
}