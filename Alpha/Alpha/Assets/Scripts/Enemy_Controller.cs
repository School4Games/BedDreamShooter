using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour 
	{
	public float Speed;
	public int damageValue = 1;
	public string tag = ("Player"); 
	public float Health = 5;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
				//Shotspawn
			if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time  + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		} 	
				//Movement
			float translation = Speed*Time.deltaTime;
			transform.position = new Vector2 (transform.position.x - translation, transform.position.y);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
		}
	}

		//SendDamage to Player
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
	}

		//HealtController
	void ApplyDamage (float damage)
	{
		
		if (Health > 0) 										// is Health bigger than 0, do the following steps
		{
			// von health wird damage abgezogen
			Health -= damage;								// it's possible /Health = Health - damage / but it is longer
			
			if (Health < 0)									// is Health lower than 0
				Health = 0;									// than put Health to 0 
			
			//what happens if Health = 0?
			if (Health == 0) 
			{
				// Enemy Death
				DestroyEnemy();
			}
		}
	}
		//ZeroHealth = Death
	void DestroyEnemy()
	{
		
		Destroy(this.gameObject); // gameObject an welchem das script dranhängt // wird aber erst ausgeführt, wenn health = 0
	}
}
