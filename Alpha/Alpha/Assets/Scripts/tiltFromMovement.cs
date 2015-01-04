using UnityEngine;
//using System.Collections;

public class tiltFromMovement : MonoBehaviour 
{
	// maximaler winkel
	public float maxAngleDegrees = 15.0f;
	//geschwindigkeit der Rotation
	public float rotationSpeed = 30.0f;
	//Anfangs Rotation muss 0 sein
	private float rotation = 0.0f;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	 void Update () 
	{
		float verticalSpeed = Input.GetAxis ("Vertical");

		rotation += rotationSpeed * Time.deltaTime * verticalSpeed;
			//Wenn rotation größer als max winkel ist 
		if (rotation > maxAngleDegrees) 
			{
				//Setzte rotations winkel dem max winkel gleich
				rotation = maxAngleDegrees;
			}
				//Soll wenn rotations winkel gleich der max rotation ist wieder auf 0 gesetzt werden 

			if (rotation == maxAngleDegrees)
				{
					rotation = 0.0f;
				}

		else if (rotation < -maxAngleDegrees) 
			{
				rotation = -maxAngleDegrees;
			}
			if (rotation == -maxAngleDegrees)
				{
					rotation = 0.0f;
				}

		this.transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
}






