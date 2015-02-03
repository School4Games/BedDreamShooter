﻿using UnityEngine;
using System.Collections;

public class Pillow_Controller : MonoBehaviour {
	//Pillow
	public float speed;
	public float rotationSpeed;
	//Damage
	public int damageValue = 1;
	public string Tag;
	public GameObject shotParticle;
	
		//Erklärt sich selbst.. wenn nicht ... Pillow bewegt sich nach rechts mit speed xy
	void Start ()
	{
		rigidbody2D.velocity = transform.right * speed;
	}

		//Kissen Routiert *hoffentlich*
	void Update()
	{
		rigidbody2D.MoveRotation (rigidbody2D.rotation + rotationSpeed * Time.deltaTime);
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

			//Versuch ein Partikelsystem zum laufen zu bringen (INGE)
			Instantiate(shotParticle, transform.position, transform.rotation );
			
		}

		if (col.gameObject.tag == Tag)
			col.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
	}
}