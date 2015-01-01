/*using UnityEngine;
using System.Collections;

public class TestingScript : MonoBehaviour 
{
	public float maxAngleDegrees = 15.0f;
	public float rotationSpeed = 30.0f;
	public float rotation = 0.0f;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	 void Update () 
	{
		float verticalSpeed = Input.GetAxis ("Vertical");

		rotation += rotationSpeed * Time.deltaTime * verticalSpeed;

		if (rotation > maxAngleDegrees) 
			{
				rotation = maxAngleDegrees;
			}

		else if (rotation < -maxAngleDegrees) 
			{
				rotation = -maxAngleDegrees;
			}

		this.transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
}*/
