using UnityEngine;
using System.Collections;

public class Health_Controller : MonoBehaviour {

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
						// GameOver
						RestartScene ();
				}
		}
	}
	void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
