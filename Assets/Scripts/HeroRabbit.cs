using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour
{

    public AudioClip walkSound = null;
    AudioSource walkSource = null;
    public AudioClip deathSound = null;
    AudioSource deathSource = null;
    public AudioClip groundSound = null;
    AudioSource groundSource = null;
    bool small;
    public float speed = 1;
    bool isGrounded = false;
    bool JumpActive = false;
    float JumpTime = 0f;
    public float MaxJumpTime = 5f;
    public float JumpSpeed = 10f;
    Rigidbody2D myBody = null;
    Transform heroParent = null;
    float deathAnimationTime = 5f;
    bool respawn = false;
    public static HeroRabbit lastRabit = null;
    

    // Use this for initialization
    void Start()
    {
        walkSource = gameObject.AddComponent<AudioSource>();
        walkSource.clip = walkSound;
        deathSource = gameObject.AddComponent<AudioSource>();
        deathSource.clip = deathSound;
        groundSource = gameObject.AddComponent<AudioSource>();
        groundSource.clip = groundSound;
        myBody = this.GetComponent<Rigidbody2D>();
        LevelController.current.setStartPosition(transform.position);
        this.heroParent = this.transform.parent;
        small = true;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //[-1, 1]
        float value = Input.GetAxis("Horizontal");
        Animator animator = GetComponent<Animator>();
        if (Mathf.Abs(value) > 0)
        {



            if (isGrounded)
                animator.SetBool("run", true);
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }
        else
        {
            animator.SetBool("run", false);
        }
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }

        //animator.SetBool ("die", false);
        Vector3 from = transform.position + Vector3.up * 0.6f;
        Vector3 to = transform.position + Vector3.down * 0.001f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
            if (SoundManager.Instance.isSoundOn())
            {
                walkSource.Play();
            }
        }
        else
        {

            isGrounded = false;
        }
        //Згадуємо ground check
        layer_id = 1 << LayerMask.NameToLayer("MovingPlatform");
        hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
            //Перевіряємо чи ми опинились на платформі
            if (hit.transform != null
                && hit.transform.GetComponent<MovingPlatform>() != null)
            {
                //Приліпаємо до платформи
                SetNewParent(this.transform, hit.transform);
            }
        }
        else
        {
            //Ми в повітрі відліпаємо під платформи
            SetNewParent(this.transform, this.heroParent);
        }
        //Намалювати лінію (для розробника)
        Debug.DrawLine(from, to, Color.red);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
            animator.SetBool("run", false);
            //Якщо кнопку ще тримають
            if (Input.GetButtonDown("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (2.5f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }

        if (this.isGrounded)
        {
            if (SoundManager.Instance.isSoundOn())
            {
                groundSource.Play();
            }
            animator.SetBool("jump", false);
        }
        else
        {
         
            animator.SetBool("jump", true);
            animator.SetBool("run", false);
        }

        //Death
        if (deathAnimationTime >= 0.2f)
        {
            deathAnimationTime -= Time.deltaTime;
        }
        else
        {

            animator.SetBool("die", false);
            if (respawn)
            {
                respawn = false;
               
                LevelController.current.onRabbitDeath(this);
            }

        }

    }

    static void SetNewParent(Transform obj, Transform new_parent)
    {
        if (obj.transform.parent != new_parent)
        {
            //Засікаємо позицію у Глобальних координатах
            Vector3 pos = obj.transform.position;
            //Встановлюємо нового батька
            obj.transform.parent = new_parent;
            //Після зміни батька координати кролика зміняться
            //Оскільки вони тепер відносно іншого об’єкта
            //повертаємо кролика в ті самі глобальні координати
            obj.transform.position = pos;
        }
    }
    public bool isSmall()
    {
        return small;
    }
    public void setSmall(bool value)
    {
        small = value;
    }
    public void callDie(float time)
    {
        print("begin of callDie");
        Animator animator = GetComponent<Animator>();
        animator.SetBool("die", true);

        this.transform.localScale = new Vector3(1f, 1f, 0);

        print("end of callDie");
        deathAnimationTime = 1;
        respawn = true;

        if (SoundManager.Instance.isSoundOn())
        { 
            deathSource.Play();
        }
    }
    public void callDie()
    {
        print("begin of callDie");
        Animator animator = GetComponent<Animator>();
        animator.SetBool("die", true);

        this.transform.localScale = new Vector3(1f, 1f, 0);

        print("end of callDie");
        deathAnimationTime = 1;
        respawn = true;

        if (SoundManager.Instance.isSoundOn())
        {
            deathSource.Play();
        }
    }
    void Awake()
    {
        lastRabit = this;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Намагаємося отримати компонент 
        // SelfControl rabit = collider.GetComponent<SelfControl>();
        OrcGreen orc = collider.GetComponent<OrcGreen>();

        if (orc != null)
        {
            if (collider == orc.head)
                orc.callDie();
            if (collider == orc.body)
            {
                orc.callPunch();
                this.callDie();
            }

        }
        BrownOrc brownOrc = collider.GetComponent<BrownOrc>();
        if (brownOrc != null)
        {
            if (collider == brownOrc.head)
                brownOrc.callDie();

        }
    }

}
