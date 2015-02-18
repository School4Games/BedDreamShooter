using UnityEngine;
using System.Collections;

public class SoundGame : MonoBehaviour {




	// Use this for initialization
	void Start () {
	
		PlayerPrefs.GetInt ("AudioToggle");


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
}
