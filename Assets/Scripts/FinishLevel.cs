using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour
{
    public BoxCollider2D door;
    public GameObject winPopUp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Намагаємося отримати компонент 
        // SelfControl rabit = collider.GetComponent<SelfControl>();
        HeroRabbit rabbit = collider.GetComponent<HeroRabbit>();

        if (rabbit != null)
        {
            Time.timeScale = 0.0f;
            GameObject parent = UICamera.first.transform.parent.gameObject;
            GameObject obj = NGUITools.AddChild(parent, winPopUp);

             
            //Створити Prefab


        }
        
    }

}
