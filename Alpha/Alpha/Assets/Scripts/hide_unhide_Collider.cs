using UnityEngine;
using System.Collections;

public class hide_unhide_Collider : MonoBehaviour {
	public KeyCode onKey = KeyCode.Y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.collider2D.enabled = Input.GetKey (onKey);
/* 		if (Input.GetKeyDown(onKey)) {
			// show
			this.collider2D.enabled = true;
		}
		
		if (Input.GetKeyDown(offKey)) {
			// hide
			this.collider2D.enabled = false;
		}
*/	
	}
}