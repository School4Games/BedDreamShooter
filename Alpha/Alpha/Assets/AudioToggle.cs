using UnityEngine;
using System.Collections;


public class AudioToggle : MonoBehaviour {

	public GameObject On;
	public GameObject Off;
	//public bool MenuOn;
	//public Color yellow = Color.yellow
	// Use this for initialization


	
	void Start ()
	{

		//AudioOn ();
		ColorChange ();
	}



	void Update()
	{
	
	
	if (PlayerPrefs.GetInt ("AudioToggle") > 0) {
		AudioListener.pause = false;
	} 
	else {
		AudioListener.pause = true;
	}
}


	public void ColorChange () {

	//Überprüfe ob Playerprefs AudioToggle 0 oder 1 ist und Enable oder Disable Button



		if (PlayerPrefs.GetInt ("AudioToggle") > 0) {



			
			On.gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;
			Off.gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;
		
		} 
		else {

			On.gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;
			Off.gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;

		}
	}

	//Audio On setzt Playerprefs Audiotoggle auf 1 - Audio Off auf 0
	public void AudioOn ()
	{
		PlayerPrefs.SetInt ("AudioToggle", 1);
	}

	public void AudioOff ()
	{
		PlayerPrefs.SetInt ("AudioToggle", 0);
	}



}
