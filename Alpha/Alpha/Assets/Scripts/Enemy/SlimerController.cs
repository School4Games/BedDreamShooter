using UnityEngine;
using System.Collections;

public class SlimerController : MonoBehaviour 
{

	public float Speed;
	public Vector2 movementDirection = new Vector2(-1,0);

	private float LostTime = 2f;
	public Color ColorOne;
	public Color ColorTwo;
	public GameObject PartGreen;
	public GameObject PartRed;


	public int damageValue = 1;
	public string Tag; 
	public float Health = 2;
	public int scoreValue = 10;
	//public bool Intrigger;
	// Use this for initialization

	//Vars from SlimerShot Script
	public GameObject shot;
	public Transform shotSpawn;
	public float Timer;
	public float ResetTimer;

	void Start () {

		ResetTimer = Timer;
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Timer <= 0) 
		{
			Fire ();
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

	void Fire()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
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
			
			{
				if (other.gameObject.tag == "Player")
					{
						Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
						
					}
			}
		
	}
	
		//HealtController
	void ApplyDamage (float damage)
	{
		
			if (Health > 0) 										// is Health bigger than 0, do the following steps
			{
				// von health wird damage abgezogen
				Health -= damage;								// it's possible /Health = Health - damage / but it is longer
				

				if (Health == 1)
		
				ColourChanging ();
				DeactivateParticle();
				StartCoroutine("DoubleShot");
			Speed = Speed + 1;
				
				

			//PartGreen.SetActive = false;
			//PartRed.SetActive = true;



				if (Health < 0)									// is Health lower than 0
					Health = 0;									// than put Health to 0 
				
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
		Fire ();
		yield return new WaitForSeconds (0.5f);
		Fire ();
	}


	void DeactivateParticle ()
	{
		PartGreen.SetActive(false);
		PartRed.SetActive (true);
	}


	void ColourChanging()
	{
		
		//Bestimmung der bereits vergangenen Zeit, seitdem die Taschenlampe auf den Geist zielt
		float Time1 = Time.deltaTime;
		float Time2 = Time.deltaTime + LostTime;
		//Farb- und Alphawert-Änderung durch LERP
		this.gameObject.renderer.material.color = Color.Lerp (ColorOne, ColorTwo, Time2/Time1);
		
	}

		//ZeroHealth = Death
	void DestroyEnemy()
	{
		
		Destroy(this.gameObject); // gameObject an welchem das script dranhängt // wird aber erst ausgeführt, wenn health = 0
	}
}
