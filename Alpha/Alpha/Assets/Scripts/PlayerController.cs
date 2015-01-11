using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	//Bed
	public float speed;
	public float rotation; 
	public Boundary boundary;

	//Shot
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	//LifePoints
	public float Health = 5;
	//public AudioSource atmo;
	
	void Start()
	{
	
	}
	
	void Update ()
	{
		// wenn rechtemaustaste gedrückt wird, wird ein Schuss am Player gespawnt 
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		} 

	}

	
	void FixedUpdate ()
	{
				//zuweisung der keys w,a,s,d || Arrowkeys & velocity

				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
		
				Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
				rigidbody2D.velocity = movement * speed;
		
				rigidbody2D.position = new Vector3 
			(
				//boundary auf x und y axe
				Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax), 

				Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax)
				);
				
				//rigidbody.rotation = Quaternion.Euler (0f, 0f, rigidbody.velocity.x * -tilt);  			// Anscheint gibt es probleme mit Quaternion.Euler und rigidbody2D.rotation
				//rigidbody2D.MoveRotation(rigidbody2D.rotation + speed * Time.deltaTime); / von Unity kopiert
				//Rigidbody2D.rotation = (Rigidbody2D.rotation + speed * Time.deltaTime); // Rotiert leider permanent 
	}

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
				// GameOver
				RestartScene ();
			}
		}
	}
	void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
