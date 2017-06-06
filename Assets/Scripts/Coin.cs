public class Coin : Collectable {

    public static int count = 0;

	protected override void OnRabitHit (HeroRabbit rabit)
	{
	 
		this.CollectedHide ();
        CoinsController.current.increase();
	}
}