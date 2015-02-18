using UnityEngine;
using System.Collections;

public class MousePointer : MonoBehaviour {

	public Texture2D cursorImage;
	
	private int cursorWidth = 64;
	private int cursorHeight = 64;
	
	void Start()
	{
		Screen.showCursor = false;
	}
	
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Input.mousePosition.x - 20, Screen.height - Input.mousePosition.y -10, cursorWidth, cursorHeight), cursorImage);
	}
}
