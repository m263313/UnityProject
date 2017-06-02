using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfControl : MonoBehaviour {
  
    public Vector3 pointA;
  public  Vector3 pointB;
    public enum Mode
    {
        GoToA,
        GoToB,
        Attack
        //...
    }
   protected Mode prev;
   protected Mode mode = Mode.GoToA;
    // Use this for initialization

 
     
	
	 

   public bool isArrived()
    {
        float curr = this.transform.position.x;
        Mathf.Abs(curr - pointA.x);
        if(mode==Mode.GoToA)
            return Mathf.Abs(curr - pointA.x) < 0.5f;
        if(mode == Mode.GoToB)
            return Mathf.Abs(curr - pointB.x) < 0.5f;
        return false;
    }
}
