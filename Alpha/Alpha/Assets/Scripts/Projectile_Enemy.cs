using UnityEngine;
using System.Collections;

public class Projectile_Enemy : MonoBehaviour 
{			
	/* Aktuelle Eigenschafften :
								Speed,
								Zerstört sich selbst wenn es Boundary verlässt,
								sendet damage an player */
																					 
	public float Speed;																 
	public float damageValue = 1;
	public string tag = ("Player"); 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float translation = Speed*Time.deltaTime;
		transform.position = new Vector2 (transform.position.x - translation, transform.position.y);
	}



	//Destroy Object when leaving Boundary
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
			
		{
			if (other.gameObject.tag == "Player")
			{
				Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
				
			}
		}
	
	}
}


