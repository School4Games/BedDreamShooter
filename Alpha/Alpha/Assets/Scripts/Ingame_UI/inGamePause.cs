using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inGamePause : MonoBehaviour 
{
	public bool breaker;
	public GameObject pause;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (PauseCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	// Pause
	IEnumerator PauseCoroutine()
	{
		while(true)
		{

			if (Input.GetKeyDown (KeyCode.P))
			{
				//this.GameObject.SetActive(false);

				if (Time.timeScale == 0)

				
				{
					Time.timeScale = 1;

				
				}
				else
				{
					Time.timeScale = 0;
					//this.GameObject.SetActive(true);
				
				}
			}
			
				yield return null;
		}
	}
}
