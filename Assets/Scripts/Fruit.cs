[System.Serializable]
public class Fruit : Collectable {

    private void Start()
    {
        if (FruitController.current.fruitsCollected.Contains(this))
            this.CollectedHide();
    }
    protected override void OnRabitHit (HeroRabbit rabit)
	{

		this.CollectedHide ();
        increase();
        FruitController.current.fruitsCollected.Add(this);
	}
    void increase()
    {
        FruitController.current.increase();
    }
}