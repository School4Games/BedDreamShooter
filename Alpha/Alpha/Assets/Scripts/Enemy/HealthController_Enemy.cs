using UnityEngine;
using System.Collections;

public class HealthController_Enemy : MonoBehaviour {

	
	public float Health = 5;							// start life 
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void ApplyDamage (float damage)
	{
		
		if (Health > 0) 										// is Health bigger than 0, do the following steps
		{
			// von health wird damage abgezogen
			Health -= damage;								// it's possible /Health = Health - damage / but it is longer
			
			if (Health < 0)									// is Health lower than 0
				Health = 0;									// than put Health to 0 
			
			//what happens if Health = 0?
			if (Health == 0) 
			{
				// Enemy Death
				DestroyEnemy();
			}
		}
	}
	void DestroyEnemy()
	{

		Destroy(this.gameObject); // gameObject an welchem das script dranhängt // wird aber erst ausgeführt, wenn health = 0
	}
	
}