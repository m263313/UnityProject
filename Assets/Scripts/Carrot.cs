using UnityEngine;
using System.Collections;

public class Carrot : Collectable
{
    float time_to_wait = 0.1f;
    public float pause = 0.1f;
    float step = 1f;
    float dir=0;
    SpriteRenderer sr;
    void Start()
    {
         sr = GetComponent<SpriteRenderer>();
        StartCoroutine(destroyLater());
    }
    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
    void FixedUpdate()
    {
        float delta = Time.deltaTime;
        
        time_to_wait -= delta;
        if (time_to_wait <= 0)
        {
            time_to_wait = pause;
            Vector3 my_pos = this.transform.position;
            if (dir > 0.1f)
                my_pos.x += step;
            else
            {
                sr.flipX = true ;
                my_pos.x -= step;
            }
            this.transform.position = my_pos;
        }
    }
        public void launch(float direction)
    {
        dir = direction;
    }
    protected override void OnRabitHit(HeroRabbit rabit)
    {
        LevelController.current.onRabbitDeath(rabit);
        this.CollectedHide();
    }

}