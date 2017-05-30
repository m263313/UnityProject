public class Mushroom : Collectable {
	protected override void OnRabitHit (HeroRabbit rabit)
	{
		
		rabit.transform.localScale = new UnityEngine.Vector3(2,2,0);
		rabit.setSmall (false);
		this.CollectedHide ();
	}
}