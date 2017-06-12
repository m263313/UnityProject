using UnityEngine;
using System.Collections;

public class OrcGreen : SelfControl
{
    public AudioClip attackSound = null;
    AudioSource attackSource = null;
    public BoxCollider2D head;
    public BoxCollider2D body;
    float pause = 0.1f;
    float time_to_wait = 0.1f;
    public float step;
    bool direction;
    float deathAnimationTime = 5f;
    bool respawn = false;
    bool shouldDie = false;
    bool flipStatus;
    SpriteRenderer sr;
    Animator animator;
    // Use this for initialization
    void Start()
    {

        attackSource = gameObject.AddComponent<AudioSource>();
        attackSource.clip = attackSound;
        pointA = this.transform.position;
        mode = Mode.GoToB;
        animator = GetComponent<Animator>();

        direction = (pointA.x - pointB.x)<0;
        


              //  animator.SetBool("run", true)
        step = 0.1f;
        if (!direction)
            step = -step;
        sr= GetComponent<SpriteRenderer>();
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
        

        time_to_wait -= Time.deltaTime;
        if (time_to_wait <= 0)
        {
            time_to_wait = pause;
            Vector3 my_pos = this.transform.position;
            if (mode == Mode.GoToA)
            {
              
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
                if (dir < 0.02f)
                {
                    my_pos.x += step;
                    sr.flipX = false;
                }
                if (dir > 0.02f)
                {
                    my_pos.x -= step;
                    sr.flipX = true;
                }
            }
            this.transform.position = my_pos;
        }
        
    }
    protected float getDirection()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        if (rabit_pos.x > Mathf.Min(pointA.x, pointB.x) && rabit_pos.x < Mathf.Max(pointA.x, pointB.x))
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
         
        Animator animator = GetComponent<Animator>();
        animator.SetBool("death", true);
 

       
        deathAnimationTime = 1;
        shouldDie = true;


    }
    public void callPunch()
    {

        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("punch");
     //   animator.ResetTrigger("punch");





    }

}
