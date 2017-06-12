using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOrc : SelfControl {
    public AudioClip attackSound = null;
    AudioSource attackSource = null;
    public BoxCollider2D head;
    public GameObject prefabCarrot;
    float pause = 0.1f;
    float time_to_wait = 0.1f;
    bool flipStatus;
    public float step;
    bool direction;
    float radius=5f;
    float last_carrot = 0;
    bool shouldDie = false;
    float deathAnimationTime = 5f;
    Animator animator;
    SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        attackSource = gameObject.AddComponent<AudioSource>();
        attackSource.clip = attackSound;

        pointA = this.transform.position;
        mode = Mode.GoToB;
      animator  = GetComponent<Animator>();

        direction = (pointA.x - pointB.x) < 0;
        step = 0.1f;
        if (!direction)
            step = -step;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //Death
        if (shouldDie)
        {
            if (deathAnimationTime >= 0.2f)
            {
                deathAnimationTime -= Time.deltaTime;
            }
            else
            {

                Destroy(this.gameObject);

            }
            return;
        }

        float delta = Time.deltaTime;
        time_to_wait -= delta;

        if (time_to_wait <= 0)
        {
            time_to_wait = pause;
            Vector3 my_pos = this.transform.position;
            if (mode == Mode.GoToA)
            {
                animator.SetBool("walk", true);
                if (isArrived())
                {

                    sr.flipX = false;
                    flipStatus = false;
                    mode = Mode.GoToB;
                    prev = Mode.GoToB;
                }
                my_pos.x -= step;
            }
            else if (mode == Mode.GoToB)
            {
                animator.SetBool("walk", true);
                if (isArrived())
                {

                    sr.flipX = true;
                    flipStatus = true;
                    mode = Mode.GoToA;
                    prev = Mode.GoToA;
                }
                my_pos.x += step;
            }
            //if (mode == Mode.GoToA)
            //{
            float dir = getDirection();

            if (mode == Mode.Attack)
            {
                if (SoundManager.Instance.isSoundOn())
                
                    attackSource.Play();
                animator.SetBool("walk", false);
                if (dir < 0.02f)
                {
                    // my_pos.x += step;
                    if (Time.time - last_carrot > 2.0f)
                    {
                        callThrow();
                        launchCarrot(dir);
                        
                        last_carrot = Time.time;

                    }
                    sr.flipX = false;
                  
                }
                if (dir > 0.02f)
                {
                    if (Time.time - last_carrot > 2.0f)
                    {
                        callThrow();
                        launchCarrot(dir);
                        last_carrot = Time.time;
                        
                    }
                        sr.flipX = true;
                    
                }
            }
            this.transform.position = my_pos;
        }
      
    }


    //  animator.SetBool("run", true)

    void launchCarrot(float direction)
    {
        //Створюємо копію Prefab
        GameObject obj = GameObject.Instantiate(this.prefabCarrot);
        //Розміщуємо в просторі
        Vector3 temp = this.transform.position;
        temp.y += 0.4f;
        obj.transform.position = temp;

       
        //Запускаємо в рух
        Carrot carrot = obj.GetComponent<Carrot>();
        carrot.launch(direction);
    }
    protected float getDirection()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        if (Mathf.Abs(my_pos.x- rabit_pos.x)<radius)
        {
            if (mode != Mode.Attack)
                prev = mode;
            mode = Mode.Attack;
        }
        else
        if (mode == Mode.Attack)
        {
            sr.flipX = flipStatus;
            mode = prev;
        }
        if (mode == Mode.Attack)
        {
            //Move towards rabit
            if (my_pos.x < rabit_pos.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        if (mode == Mode.GoToA)
        {
            //Direction depending on target
            if (my_pos.x < pointA.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        if (mode == Mode.GoToB)
        {
            //Direction depending on target
            if (my_pos.x > pointB.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        return 0;
    }
    public void callDie()
    {

        
        animator.SetBool("death", true);



        deathAnimationTime = 1;
        shouldDie = true;


    }
    public void callThrow()
    {

         
        animator.SetTrigger("throw");
  





    }
}
