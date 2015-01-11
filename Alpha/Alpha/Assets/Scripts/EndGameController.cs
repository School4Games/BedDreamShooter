using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour 
{

	public float timeLeft = 10.0f;

	void Start ()
	{

	}

	// Update is called once per frame
	void Update () 
	{	
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			Debug.Log("mann ey");
			//Application.LoadLevel (Application.loadedLevel);
			//Application.Quit();
			//Application.CancelQuit();
			Application.LoadLevel("MENU UNITY");
			
		}

	}
}
