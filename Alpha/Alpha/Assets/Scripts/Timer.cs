using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	
	public float timer;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Light") 
		{
			timer = timer -1;
			if (timer < 0)
			{
			timerTime ();
			}
		}
		
	}
	void timerTime()
	{
				Destroy (gameObject);
	}
}

