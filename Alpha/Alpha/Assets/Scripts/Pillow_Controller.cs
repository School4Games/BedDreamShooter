using UnityEngine;
using System.Collections;

public class Pillow_Controller : MonoBehaviour {

	public float speed;
	public float rSpeed;
	
		//Erklärt sich selbst.. wenn nicht ... Pillow bewegt sich nach rechts mit speed xy
	void Start ()
	{
		rigidbody2D.velocity = transform.right * speed;
	}

		//Kissen Routiert *hoffentlich*
	void Update()
	{
		rigidbody2D.MoveRotation (rigidbody2D.rotation + rSpeed * Time.deltaTime);
	}

		//Zerstört sich selbst wenn es aus der Boundary rausgeht (Exit) NIEMALS DAS 2D vergessen bei einem 2D GAME -.-"
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
		}
	}

		// Pillow wird zerstört wenn es Slimer trifft
	void OnTriggerEnter2D(Collider2D col)
		
	{
		if (col.gameObject.tag == "Slimer")
		{
			Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
			
		}
	}
}