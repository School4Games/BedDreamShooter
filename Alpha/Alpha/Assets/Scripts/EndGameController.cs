using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour 
{
	public float speed;

	void Start ()
	{
		rigidbody2D.velocity = transform.right * speed;
	}

	// Update is called once per frame
	void Update () 
	{	// wenn das Objekt da ist, console = get one
		//wenn es nicht da ist sollte eigentlich das level neu gestartet werden
		/*
		if (gameObject != null) 
		 {
			Debug.Log ("get one");
		 } 
		else 
		 {
			Application.LoadLevel (Application.loadedLevel);
		 }*/

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject, 0.5f);
		}

	}
}
