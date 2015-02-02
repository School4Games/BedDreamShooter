﻿using UnityEngine;
using System.Collections;

public class SmallGhostController : MonoBehaviour 
{

	public float damageValue = 1;
	public string tag = ("Player"); 
	public float deathTimer;
	private bool startTimer;
	private bool Timercheck;
	public GameObject SoundObject;




	//Finder
	private Vector3 characterPos; 
	private Vector3 playerPos;
	private GameObject player;
	private Vector3 movementDir;
	public float speed;
	// Use this for initialization

	void Start () 
	
	{
		Finder ();
	
	}

	void Update()

	{
		Timercheck = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().falshlightCheck;
	}
	void Finder()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		characterPos = this.transform.position;
		playerPos = player.transform.position;
		
		movementDir = playerPos - characterPos;
		movementDir = movementDir.normalized;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position += movementDir * speed;

	}
	void Death()
	{
		//
		Timercheck = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().falshlightCheck;
		
		
		if (!Timercheck && startTimer) 
			
		{
			startTimer = false;
		}
		
		if (startTimer) 
			
		{
			deathTimer -= Time.deltaTime;
		}
		if (deathTimer < 0) 
			
		{
			Destroy (this.gameObject);
		}
	}
	
	
	//Destroy Object when leaving Boundary
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
		{
			startTimer = false;
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
				Instantiate(SoundObject, transform.position, transform.rotation);
			}
		}
		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
		{
			startTimer = true;
			
		}
		
	}
}

