using UnityEngine;
using System.Collections;

public class Ingefinger : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//this.renderer.enabled = (Input.GetKey(KeyCode.I)) && (Input.GetKey(KeyCode.N));		
		this.particleSystem.enableEmission = (Input.GetKey(KeyCode.I)) && (Input.GetKey(KeyCode.N));
	}

}
//Input.GetKey (Input.GetKey(KeyCode.I)) && (Input.GetKey(KeyCode.N)) && (Input.GetKey(KeyCode.G)) && (Input.GetKey(KeyCode.E));