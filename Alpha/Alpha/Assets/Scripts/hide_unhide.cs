using UnityEngine;
using System.Collections;

public class hide_unhide : MonoBehaviour {
	public KeyCode onKey = KeyCode.Y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.renderer.enabled = Input.GetKey (onKey);
/*		if (Input.GetKeyDown(onKey)) {
			// show
			this.renderer.enabled = true;
		}
		
		if (Input.GetKeyDown(offKey)) {
			// hide
			this.renderer.enabled = false;
		}
*/	
	}
}

