using UnityEngine;
using System.Collections;
/*
public class HighscoreBoard : MonoBehaviour {

	public int currentScore;
	public int platz1;
	public int platz2;
	public int platz3;
	public int platz4;
	public int platz5;
	public string currentName;
	public string highName1;
	public string highName2;
	public string highName3;
	public string highName4;
	public string highName5;
	public char letter1 = "J";
	public char letter2 = "A";
	public char letter3 = "N";



	// Use this for initialization
	void Start () {


		platz1 = PlayerPrefs.GetInt ("Platz1");
		platz2 = PlayerPrefs.GetInt ("Platz2");
		platz3 = PlayerPrefs.GetInt ("Platz3");
		platz4 = PlayerPrefs.GetInt ("Platz4");
		platz5 = PlayerPrefs.GetInt ("Platz5");
		highName1 = PlayerPrefs.GetString ("HighscoreName1");
		highName2 = PlayerPrefs.GetString ("HighscoreName2");
		highName3 = PlayerPrefs.GetString ("HighscoreName3");
		highName4 = PlayerPrefs.GetString ("HighscoreName4");
		highName5 = PlayerPrefs.GetString ("HighscoreName5");



	}
	
	// Update is called once per frame
	void Update () {

		DontDestroyOnLoad(this);

		currentName = char.ToString(letter1) + char.ToString(letter2) + char.ToString(letter3);
	
		Debug.Log (currentName);
		if (currentScore > platz5 && currentScore < platz4) 
		{	
			platz5 = currentScore;
			highName5 = currentName;
			PlayerPrefs.SetInt ("Platz5", currentScore);
			PlayerPrefs.SetString("HighscoreName5", currentName);
		}

		if (currentScore > platz4 && currentScore < platz3) 
		{
			platz4 = currentScore;
			highName4 = currentName;
			PlayerPrefs.SetInt ("Platz4", currentScore);
			PlayerPrefs.SetString("HighscoreName4", currentName);
		}

		if (currentScore > platz3 && currentScore < platz2) 
		{
			platz3 = currentScore;
			highName3 = currentName;
			PlayerPrefs.SetInt ("Platz3", currentScore);
			PlayerPrefs.SetString("HighscoreName3", currentName);
		}

		if (currentScore > platz2 && currentScore < platz1) 
		{
			platz2 = currentScore;
			highName2 = currentName;
			PlayerPrefs.SetInt ("Platz2", currentScore);
			PlayerPrefs.SetString("HighscoreName2", currentName);
		}

		if (currentScore > platz1) 
		{
			platz2 = currentScore;
			highName2 = currentName;
			PlayerPrefs.SetInt ("Platz1", currentScore);
			PlayerPrefs.SetString("HighscoreName1", currentName);
		}


	}
}
*/