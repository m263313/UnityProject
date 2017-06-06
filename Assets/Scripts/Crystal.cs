public class Crystal : Collectable {
   public CrystalController.Crystals type;
    public int i = 0;
	protected override void OnRabitHit (HeroRabbit rabit)
	{
        //Visual studio
        
		this.CollectedHide ();
        changeSprite();
	}

    void changeSprite()
    {
        CrystalController.current.setCrystal(this);
    }
}