public class Bomb : Collectable {
	protected override void OnRabitHit (HeroRabbit rabit)
	{
		if (rabit.isSmall ()) {
			print ("begin of death");
			rabit.callDie (10);
			print ("end of death");
		}
		else {
			rabit.setSmall (true);
			rabit.transform.localScale= new UnityEngine.Vector3(1f,1f,0f);
		}
		this.CollectedHide ();
	}
}