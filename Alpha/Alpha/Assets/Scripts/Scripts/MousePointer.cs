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
		GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
	}
}
