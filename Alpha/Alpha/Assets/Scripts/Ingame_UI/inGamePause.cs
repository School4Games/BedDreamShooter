using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inGamePause : MonoBehaviour 
{
	public float alpha;
	public CanvasGroup pauseUI;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine (PauseCoroutine());
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKeyDown (KeyCode.P))
		{
			CanvasGroup.alpha = new Alpha(yellowFace.color.r,yellowFace.color.g,yellowFace.color.b,1);
		}
		else
		{
			CanvasGroup.alpha = 0;
		}*/
	}

	// Pause
	IEnumerator PauseCoroutine()
	{
		while(true)
		{

			if (Input.GetKeyDown (KeyCode.P))
			{
				if (Time.timeScale == 0)
				
				{
					Time.timeScale = 1;
				
				}
				else
				{
					Time.timeScale = 0;
				
				}
			}
			
				yield return null;
		}
	}
}
