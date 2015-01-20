using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inGamePause : MonoBehaviour 
{
	public bool breaker;
	public GameObject pause;
	//public GameObject reStart;
	//public Button pauseButton;
	// Use this for initialization
	public void Start () 
	{
		StartCoroutine (PauseCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (Input.GetButtonDown ("pause"))
		{
			StartCoroutine (PauseCoroutine());
		}*/
		
	}
	public void Breaker()
		{
			if (breaker == false)
			{
				breaker = true;
			}
			
		}

	// Pause
	public IEnumerator PauseCoroutine()
	{
		while(true)
		{

			if (Input.GetKeyDown (KeyCode.P) || breaker)
			{
				//this.GameObject.SetActive(false);

				AudioListener.pause = false;


				pause.SetActive(true);
				breaker = false;

				if (Time.timeScale == 0)

				
					{
						Time.timeScale = 1;

						pause.SetActive(false);

					}
				else
				//if (reStart.)
				{
					Time.timeScale = 0;
					//this.GameObject.SetActive(true);
					AudioListener.pause = true;
				
				}
			}
			
				yield return null;
		}
	}
}
