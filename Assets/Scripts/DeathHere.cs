using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour {

	//Стандартна функція, яка викличеться,
	//коли поточний об’єкт зіштовхнеться із іншим
	void OnTriggerEnter2D(Collider2D collider) {
		//Намагаємося отримати компонент кролика
		HeroRabbit rabit = collider.GetComponent<HeroRabbit> ();
		//Впасти міг не тільки кролик
		if(rabit != null) {
			rabit.transform.localScale= new UnityEngine.Vector3(1f,1f,0f);
			//Повідомляємо рівень, про смерть кролика
			LevelController.current.onRabbitDeath (rabit);

		}
	}
}
