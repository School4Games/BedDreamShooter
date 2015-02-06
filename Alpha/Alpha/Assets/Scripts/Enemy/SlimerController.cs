﻿using UnityEngine;
using System.Collections;

public class SlimerController : MonoBehaviour 
{
	//movement	
	public float Speed;
	public float AngrySpeed;
	public Vector2 movementDirection = new Vector2(-1,0);

	//Health and Death
	public float duration;
	public float smoothness;
	public Color ColorOne;
	public Color ColorTwo;
	public GameObject PartGreen;
	public GameObject PartRed;

	//WayPoints
	public int damageValue = 1;
	public string Tag; 
	public float Health = 2;
	public int scoreValue = 10;


	//Vars from SlimerShot Script
	public GameObject shot;
	public Transform shotSpawn;
	public float Timer;
	public float ResetTimer;

	void Start () 
	{
		ResetTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Timer <= 0) 
			{
				StartCoroutine("Fire");
				Timer = ResetTimer;
			} 
		else 
			{
				Timer -= Time.deltaTime;
			}
									
		Move ();

	}

	public void Move()
	
	{
		float translation = Speed*Time.deltaTime;
		
		//MoveOn(new Vector2(-translation,0));
		
		MoveOn (movementDirection * translation);
	}

	public void MoveOn(Vector2 distance)
	//Debug.Log("hakunamatata");
	{
		transform.Translate (distance);
	}


	IEnumerator Fire()
	{

		if (Health > 1) 
			{
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			} 
		
		if (Health == 1)
			{
				yield return new WaitForSeconds (2);
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
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
		if (other.gameObject.tag == Tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
			
		if (other.gameObject.tag == "Player")
			{
				Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
			}
	}
	
		//HealtController
	void ApplyDamage (float damage)
	{
		// is Health bigger than 0, do the following steps
		if (Health > 0) 										
			{
				// von health wird damage abgezogen
				Health -= damage;								// it's also possible /Health = Health - damage / but it is longer

				if (Health == 1)
		
				StartCoroutine ("ColourChangingAngry");
				DeactivateParticle();
				Speed = Speed + AngrySpeed;
				StartCoroutine("DoubleShot");
				
				// is Health lower than 0
				if (Health < 0)	
				// than put Health to 0 
					Health = 0;
				
				//what happens if Health = 0?
				if (Health == 0) 
					{
						ScoreManager.score += scoreValue;
							// Enemy Death
							DestroyEnemy();
					}
			} 
	}


	IEnumerator DoubleShot()
	{
		if (Health == 1) 
			{
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				yield return new WaitForSeconds (0.5f);
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				yield return new WaitForSeconds (1.5f);
				Speed = Speed - AngrySpeed;
				ActivateParticle();
				yield return new WaitForSeconds (0.5f);
				StartCoroutine ("ColourChangingNormal");		
			}
	}

	void DeactivateParticle ()
	{
		PartGreen.SetActive(false);
		PartRed.SetActive (true);
	}


	void ActivateParticle ()
	{
		PartGreen.SetActive(true);
		PartRed.SetActive (false);
	}


	IEnumerator ColourChangingAngry()
	{
		float progress = 0;
		float increment = smoothness/duration;

		while(progress < 1)
			{
				this.gameObject.renderer.material.color = Color.Lerp (ColorOne, ColorTwo, progress);
				progress += increment;
				yield return new WaitForSeconds(smoothness);
			}
		
		yield return true;
		
	}

	IEnumerator ColourChangingNormal()
	{
		float progress = 0;
		float increment = smoothness/duration;


		while(progress < 1)
			{
				this.gameObject.renderer.material.color = Color.Lerp (ColorTwo, ColorOne, progress);
				progress += increment;
				yield return new WaitForSeconds(smoothness);
			}
			
		yield return true;

	}

		//ZeroHealth = Death
	void DestroyEnemy()
	{
		
		Destroy(this.gameObject); // gameObject an welchem das script dranhängt // wird aber erst ausgeführt, wenn health = 0
	}
}
