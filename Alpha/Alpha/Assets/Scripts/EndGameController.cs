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
	{
	
	}
}
