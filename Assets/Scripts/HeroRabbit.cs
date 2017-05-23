using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit: MonoBehaviour {
	public float speed = 1;
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 5f;
	public float JumpSpeed = 10f;
	Rigidbody2D myBody = null;

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		LevelController.current.setStartPosition (transform.position);
	}

	void Update()
	{
 
	}
	// Update is called once per frame
	void FixedUpdate () {
		//[-1, 1]
		 
		float value = Input.GetAxis ("Horizontal");
		Animator animator = GetComponent<Animator> ();
		if (Mathf.Abs (value) > 0) {
			if(isGrounded)
			animator.SetBool ("run", true);
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		} else {
			animator.SetBool ("run", false);
		}
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if(value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}
		Vector3 from = transform.position + Vector3.up * 0.6f;
		Vector3 to = transform.position + Vector3.down * 0.001f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
		//Намалювати лінію (для розробника)
		Debug.DrawLine (from, to, Color.red);	
		
		if(Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true;
		}
		if(this.JumpActive) {
			animator.SetBool ("run", false);
			//Якщо кнопку ще тримають
			if(Input.GetButtonDown("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (2.5f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}
		 
		if(this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
			animator.SetBool ("run", false);
		}
	}
}
