using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour 
{

	public float Speed;
	public Vector2 movementDirection = new Vector2(-1,0);

	public int damageValue = 1;
	public string tag = ("Player"); 
	public float Health = 5;
	public float deathTimer;
	private bool startTimer;
	private bool Timercheck;
	//public bool Intrigger;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{	
		Timercheck = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().falshlightCheck;
																		//Movement
																	//float translation = Speed*Time.deltaTime;
																	//transform.position = new Vector2 (transform.position.x - translation, transform.position.y);

																/*if (!Timercheck && startTimer)
																	{
																		startTimer = false;
																	}

																if (startTimer) 
																{
																	deathTimer -= Time.deltaTime;
																}
																if (deathTimer < 0)
																{
																	Destroy(this.gameObject);
																	}*/
		Move ();
		GhostDeath();
	}

	void GhostDeath ()
	{
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

		//SendDamage to Player
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

			if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
					{
						startTimer = true;

					}

		
	}

	void Ghostdoom()

	{

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
