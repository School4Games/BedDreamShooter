using UnityEngine;
using System.Collections;

public class MainMenuControler : MonoBehaviour {


	public void StartGame() 
	
		{
			Application.LoadLevel ("Alpha Version");
		}

	public void ExitGame()
	
		{
			Application.Quit ();
		}

}
