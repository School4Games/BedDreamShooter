using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inGamePause : MonoBehaviour 
{
	public bool breaker;
	public GameObject pause;
	public GameObject MousePointer;
	public GameObject SoundOption;


	public void Start () 
	{
		StartCoroutine (PauseCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
	{

		
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
					
					//SoundOption.gameObject.GetComponent<AudioToggle>().MenuOn = false; 

				PlayerPrefs.GetInt ("AudioToggle");	
				AudioListener.pause = false;
					
					pause.SetActive(true);
					
					breaker = false;

					if (Time.timeScale == 0)
						{
							Time.timeScale = 1;

							pause.SetActive(false);
							//playButton.SetActive(false);
						}
					else
					//if (reStart.)
						{
							
							//PlayerPrefs.SetInt ("AudioToggle", 0);		
							Time.timeScale = 0;
							//SoundOption.gameObject.GetComponent<AudioToggle>().MenuOn = true; 
							//this.GameObject.SetActive(true);
							AudioListener.pause = true;
							PlayerPrefs.GetInt ("AudioToggle");	
						}
				}
		yield return null;
		}
	}

	public void Menu()
	{
		Application.LoadLevel ("MENU UNITY");
	}

	public void MousePointerUse()
	{

		if (breaker == true)
		{
			MousePointer.SetActive(true);
		}
		 else
		{
			MousePointer.SetActive(false);
		}

	}


}
