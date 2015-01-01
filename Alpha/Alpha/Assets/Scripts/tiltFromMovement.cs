using UnityEngine;
//using System.Collections;

public class tiltFromMovement : MonoBehaviour 
{
	// maximale Auslenkung
	public float maxAngleDegrees = 15.0f;
	// Rotationsgeschwindigkeit in Grad pro Sekunde
	public float rotationSpeed = 30.0f;
	// privater Member, der die aktuelle Rotation speichert
	public float rotation = 0.0f;
	
	public void Update() 
	{
		//rotation = 0.0f;
		// lies den aktuellen Controller-Wert für die senkrechte Positionsänderung
		float verticalSpeed = Input.GetAxis ("Vertical");
		
		// ändere den Rotationswinkel abhängig vom Input
		rotation += rotationSpeed * Time.deltaTime * verticalSpeed;
		
		// begrenze die Rotation auf den eingestellten Maximalwinkel
		if (rotation == maxAngleDegrees)
		//if (true)
		{
			rotation = maxAngleDegrees;
		}​
		
			else if (rotation == maxAngleDegrees)
		{
			rotation = -maxAngleDegrees;
		}

		// wende den Rotationswinkel an
		this.transform.rotation = Quaternion.Euler(0, 0, rotation); 

	}
}
		/* Ich habe getestet:
		 * maxAngleDegrees  durch 15.0f ersetzt
		 * rotation durch rota ersetzt um zu schauen ob es auswirkungen hat = nop
		 * jede einzelne Zeile nach und nach raus kommentiert = alles läuft bis auf if else Argumen
		 * mit FixedUpdate versucht = nop
		 * nur void Update = nop
		 * if scheint im allgemeinem nicht zu klappen*/





