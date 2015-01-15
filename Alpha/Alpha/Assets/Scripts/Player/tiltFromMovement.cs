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

		rotation += rotationSpeed * Time.deltaTime *verticalSpeed;
			//Wenn rotation größer als max winkel ist 
		if (rotation > maxAngleDegrees) 
			{
				//Setzte rotations winkel dem max winkel gleich
				rotation = maxAngleDegrees;
			}
				
		else if (rotation < -maxAngleDegrees) 
			{
				rotation = -maxAngleDegrees;
			}
		if ((verticalSpeed < 0.1) && (verticalSpeed > -0.1))
		{
			// um wieviel der Spieler in diesem Frame gedreht werden soll
			float rotationAmount = rotationSpeed * Time.deltaTime;
			
			// wenn die aktuelle Rotation zwischen +rotationAmount und -rotationAmount liegt, also so gut wie 0 ist
			if ((rotation < rotationAmount) && (rotation > -rotationAmount))
			{
				// soll sie auf 0 gesetzt werden
				rotation = 0;
			}
			// andernfalls soll sie bei positiven Werten
			else if (rotation > 0)
			{
				// verringert werden​
				rotation -= rotationAmount;
			}
			else
			{
				// und bei negativen erhöht
				rotation += rotationAmount;
			}
		}
	

		this.transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
}
/*if (Input.GetAxis(“Vertical”) == 0)

if ((verticalSpeed < 0.1) && (verticalSpeed > -0.1))

		if (rotation > 0)
	{
		// Rotation verringern
		rotation -= rotationSpeed * Time.deltaTime;
}
else
{
	// Rotation erhöhen
	rotation += rotationSpeed * Time.deltaTime;
	// wenn in vertikaler Richtung nicht gesteuert wird

if ((verticalSpeed < 0.1) && (verticalSpeed > -0.1))
	{
		// um wieviel der Spieler in diesem Frame gedreht werden soll
		float rotationAmount = rotationSpeed * Time.deltaTime;
		
		// wenn die aktuelle Rotation zwischen +rotationAmount und -rotationAmount liegt, also so gut wie 0 ist
		if ((rotation < rotationAmount) && (rotation > -rotationAmount))
		{
			// soll sie auf 0 gesetzt werden
			rotation = 0;
		}
		// andernfalls soll sie bei positiven Werten
		else if (rotation > 0)
		{
			// verringert werden​
			rotation -= rotationAmount;
		}
		else
		{
			// und bei negativen erhöht
			rotation += rotationAmount;
		}
	}
}*/




