using UnityEngine;
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
	private SpriteRenderer myShape;
	//private bool AngryState;


	//Particle
	public GameObject PartGreen;
	public GameObject PartRed;
	public GameObject PartHit;
	public GameObject PartDeath;

	//Sound
	public AudioClip[] HitSounds;
	//public AudioClip HitSound;
	public AudioClip DeathSound;

	//WayPoints
	public int damageValue = 1;
	public string Tag; 
	public float Health = 2;
	public int scoreValue = 10;


	//Vars from SlimerShot Script
	public GameObject shot;
	public Transform shotSpawn;
	public float Timer;
	public float DoubleshotCooldown = 1f; //***
	private float DoubleshotCooldownTimer = 0; //***
	public float ResetTimer;
	//private float progressA = 0;
	//private float progressN = 0;

	void Start () 
	{
		//2D-Sprite-Componente aufrufen
		myShape = GetComponent<SpriteRenderer> ();
		ResetTimer = Timer;
		//AngryState = false;
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

		DoubleshotCooldownTimer -= Time.deltaTime; //***

		Move ();
	}


	public void Move()
	{
		float translation = Speed*Time.deltaTime;
		MoveOn (movementDirection * translation);
	}


	public void MoveOn(Vector2 distance)
	{
		transform.Translate (distance);
	}


	IEnumerator Fire()
	{
		if (myShape.enabled == true)
			{
				if (Health > 1) 
					{
						
						yield return new WaitForSeconds (0.5f);
						Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
						//yield return new WaitForSeconds (0.5f);

					} 
		
		/*		if (Health == 1)
					{
						yield return new WaitForSeconds (2);
						if (myShape.enabled == true)
							{
								Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
							}
					}*/
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
		if (myShape.enabled == true)
			{
				if (other.gameObject.tag == Tag)
						other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
						
				if (other.gameObject.tag == "Player")
					{
						Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
					}
			}	
	}


	//HealtController
	void ApplyDamage (float damage)
	{
		if (myShape.enabled == true)
			{
				/*if (Health > 1)
					{
						
					}*/
				// is Health bigger than 0, do the following steps
				if (Health > 0) 										
					{
						// von health wird damage abgezogen
						audio.clip = HitSounds[Random.Range(0, HitSounds.Length)];
						audio.Play();
						Health -= damage;								// it's also possible /Health = Health - damage / but it is longer
						StartCoroutine ("ColourChangingAngry");
						DeactivateParticle();
						Speed = Speed + AngrySpeed;
						

						float timeSinceLastShot = ResetTimer - Timer; //***
						if ((DoubleshotCooldownTimer <= 0) 
				    		&& (timeSinceLastShot > 0.5f)) //***
						{ //***

							StartCoroutine("DoubleShot");
							Timer = ResetTimer;
							DoubleshotCooldownTimer = DoubleshotCooldown; //***
						} //***

							
						// is Health lower than 0

							if (Health < 0)	
								// than put Health to 0 
								Health = 0;
								//what happens if Health = 0?

									if (Health == 0) 
										{
											ScoreManager.score += scoreValue;
											// Enemy Death
											myShape.enabled = false;
											gameObject.GetComponent<BoxCollider2D>().enabled = false;
											DestroyEnemy();
										}
					} 
			}
	}


	IEnumerator DoubleShot()
	{
		if (myShape.enabled == true)
			{
				PartHit.SetActive (false);
				HitParticle ();
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				yield return new WaitForSeconds (0.5f);
					


			if (myShape.enabled == true)
						{
							
							Instantiate (shot, shotSpawn.position, shotSpawn.rotation);		
							Speed = Speed - AngrySpeed;
							ActivateParticle();
							StartCoroutine ("ColourChangingNormal");
							Debug.Log("NORMAL");
							//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
						}

					
						
				/*	if (myShape.enabled == true)
						{
							Speed = Speed - AngrySpeed;
							ActivateParticle();
							StartCoroutine ("ColourChangingNormal");
						}

					yield return new WaitForSeconds (0.5f);
						
					/*if (myShape.enabled == true)
						{
							StartCoroutine ("ColourChangingNormal");	
						}*/	
			}
	}




	void HitParticle ()
	{
		PartHit.SetActive (true);
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
		float progressA = 0;
		float increment = smoothness/duration;
		Debug.Log ("AngryProgress:" + progressA);

		while(progressA < 1)
			{
				this.gameObject.renderer.material.color = Color.Lerp (ColorOne, ColorTwo, progressA);
				progressA += increment;
				yield return new WaitForSeconds(smoothness);
			}
		yield return true;
	}


	IEnumerator ColourChangingNormal()
	{

		float progressN = 0;
		Debug.Log ("NormalProgress:" + progressN);
		//Debug.Log ("NORMAL");
		float increment = smoothness/duration;

		while(progressN < 1)
			{
				this.gameObject.renderer.material.color = Color.Lerp (ColorTwo, ColorOne, progressN);
				progressN += increment;
				yield return new WaitForSeconds(smoothness);
			}
			
		yield return true;

	}


	//ZeroHealth = Death
	void DestroyEnemy()
	{
		PartDeath.SetActive (true);
		PartGreen.SetActive(false);
		PartRed.SetActive (false);
		PartHit.SetActive (false);
		audio.PlayOneShot (DeathSound, 1.0F);
		Destroy(this.gameObject, 2f);; // gameObject an welchem das script dranhängt // wird aber erst ausgeführt, wenn health = 0
	}
}
