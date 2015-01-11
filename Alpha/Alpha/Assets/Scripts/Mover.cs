using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public float rSpeed;
	
	void Start ()
	{
		rigidbody2D.velocity = transform.right * speed;
	}

	void Update()
	{
		rigidbody2D.MoveRotation (rigidbody2D.rotation + rSpeed * Time.deltaTime);
	}
	 
}