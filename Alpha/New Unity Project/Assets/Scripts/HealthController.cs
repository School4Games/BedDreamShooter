using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public float currentHealth = 5;				// start life
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ApplyDamage (float damage)
	{

		if (currentHealth > 0)					// currentHealth > 0, dann mach folgendes:
		{
			currentHealth -= damage;			// schaden von dern lifepoints abziehen | currentHealth = currentHealth - damage

			if (currentHealth < 0)				// wenn currentHealth unter 0 ist 
				currentHealth = 0;				// setzte currentHealth auf 0

			if (currentHealth ==0)				//wenn currentHealth = 0 
			{
				//GameOver?#
				RestartScene(); 				// starte Scene neu
			}
		}
	}

	void RestartScene()							
	{
		Application.LoadLevel (Application.loadedLevel);			// Level wird neu gestartet
	}
}

