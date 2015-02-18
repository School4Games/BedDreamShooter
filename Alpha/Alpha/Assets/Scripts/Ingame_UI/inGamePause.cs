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

				AudioSource audioSource = SoundOption.GetComponent<AudioSource>();
					
				PlayerPrefs.GetInt ("AudioToggle");	

				pause.SetActive(true);
					




					breaker = false;

					if (Time.timeScale == 0)
						{
							Time.timeScale = 1;

					if (PlayerPrefs.GetInt ("AudioToggle") > 0)
					{
							audioSource.Play();

					}
							pause.SetActive(false);
							
					
						}
					else
					//if (reStart.)
						{
							
								
							Time.timeScale = 0;
									
							
								
						//	PlayerPrefs.GetInt ("AudioToggle");	
					audioSource.Pause();
					Debug.Log("NA");
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


	public void SoundTest()

	{
		AudioSource audioSource = SoundOption.GetComponent<AudioSource>();
		audioSource.Play();
	}

}
