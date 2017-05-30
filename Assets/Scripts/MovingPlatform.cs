 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	//class MovingPlatform
	public Vector3 MoveBy;
	float time_to_wait = 0.1f;
public	float pause =0.1f;
	 Vector3 pointA;
	 Vector3 pointB;
	Vector3 step;
	 int partOfStep = 100;
	public float timeToStay = 1f;
	float stopTime;
	 bool going_to_a;
	// Use this for initialization
	void Start () {
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;
		step = (this.pointB - this.pointA)/partOfStep;
		going_to_a = false;
		stopTime = timeToStay;
	}
		
	void FixedUpdate(){


		time_to_wait -= Time.deltaTime;
		if(time_to_wait <= 0) {
			time_to_wait = pause;
			Vector3 my_pos = this.transform.position;
			Vector3 target;

			if(going_to_a) {
				target = this.pointA;
			} else {
				target = this.pointB;
			}
			Vector3 destination = target - my_pos;
			destination.z = 0;
			if (going_to_a) {
				this.transform.position -= step;
			} else {
				this.transform.position += step;
			}
			if(isArrived(my_pos,target)){
				time_to_wait += stopTime;
				going_to_a = !going_to_a;
			}

		}

	}
	bool isArrived(Vector3 pos, Vector3 target) {
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}



 



}
