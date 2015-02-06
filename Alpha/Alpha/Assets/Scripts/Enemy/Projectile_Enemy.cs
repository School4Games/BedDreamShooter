using UnityEngine;
using System.Collections;

public class Projectile_Enemy : MonoBehaviour 
{			

																					 
	public float Speed;																 
	public float damageValue = 1;
	public string Tag; 
	public float deathTimer;
	private bool startTimer;
	public GameObject SoundObject;
	private bool Timercheck;

	// Use this for initialization
	void Start () 
	
	{
	

	}
	
	// Update is called once per frame
	void Update ()
	{
		Death ();
	}

	void Death()
	{
		Timercheck = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().falshlightCheck;
		
		float translation = Speed*Time.deltaTime;
		transform.position = new Vector2 (transform.position.x - translation, transform.position.y);
		
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
				Destroy(this.gameObject);
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
		if (other.gameObject.tag == Tag)
			other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
			
		if (other.gameObject.tag == "Player")
			{
				Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
				Instantiate(SoundObject, transform.position, transform.rotation);
			}
			

		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
			{
				startTimer = true;
			}
	}

}


