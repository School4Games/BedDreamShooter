using UnityEngine;
using System.Collections;

public class theFinger : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.renderer.enabled = (Input.GetKey(KeyCode.I)) && (Input.GetKey(KeyCode.N));
	}
}
