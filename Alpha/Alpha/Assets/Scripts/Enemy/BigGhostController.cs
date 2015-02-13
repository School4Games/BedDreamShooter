using UnityEngine;
using System.Collections;

public class BigGhostController : MonoBehaviour 
{
	//movement	
	private float Speed = 0.0f;
	public Vector2 movementDirection = new Vector2(-1,0);

	//Health and Death
	public float deathTimer;
	private bool startTimer;
	private bool Timercheck;
	private bool NewTimer;
	public int scoreValue;
	public int damageValue = 1;
	public string Tag;

	//WayPoints
	public float patrolSpeed = 3f;       // Geschwindigkeit zwischen den Waypoints
	public float pauseDuration = 0;   	// pause zwischen den waypoints Waypoint
	public GameObject Waypoints;
	private float curTime;
	private GameObject[] currentWaypoints;
	private int Wcounter = 0;
	private bool Wspwaned;
	private bool Targetreached;
	public Vector3 spawnValues;
	public float Timer;

	//Partikeleffekte
	public GameObject BurnPart;
	public GameObject CottonPart;
	public Color ColorOne;
	public Color ColorTwo;
	private float LostTime = 0;
	private SpriteRenderer myShape;

	//SmallGhost Spawn
	public GameObject smalGhosts;
	public GameObject Spawn1;
	public GameObject Spawn2;

	//Sounds
	public AudioSource FlashlightHit;

	//private Enemy_Controller character; 

	// Use this for initialization
	void Start () 
	{
		//Komponente vom 2D Sprite
		myShape = GetComponent<SpriteRenderer> ();


		currentWaypoints = new GameObject[3];
		Spawn (Waypoints);
		gettarget ();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(Wspwaned)
		{
			gettarget ();
		}
		if (Timer < 0)
		{
			Timer = 0;
		}
		
		Move ();
		GhostDeath();
	}


	void gettarget()
	{	
		if (Timer <= 10) 
		{
			Timer -= Time.deltaTime;
		}
		
		Vector3 target = currentWaypoints [Wcounter].transform.position;
		patrol (target);
		
		if (Targetreached && Timer <= 0) 
		{
			Timer = 3;
			Wcounter++;

			//nur wenn das 2D Sprite vom Geist an ist, dann....
			//if (myShape.enabled == true) 
			//{
				StartCoroutine("SmallGhosts");
			//}
		}

	}


	IEnumerator SmallGhosts()
	{
		yield return new WaitForSeconds (Timer/2);
		if (myShape.enabled == true) 
		{
			Instantiate (smalGhosts, Spawn1.transform.position, Quaternion.identity);
			Instantiate (smalGhosts, Spawn2.transform.position, Quaternion.identity);
		}
	}


	void  patrol (Vector3 target)
	{
		// Keep waypoint at character's height
		target.z = transform.position.z; 
		Vector3 moveDirection = target - transform.position;
		
		if(moveDirection.magnitude < 0.5f)
		{
			if (curTime == 0)
				// Pause over the Waypoint
				curTime = Time.time; // 
			if ((Time.time - curTime) >= pauseDuration)
			{
				//currentWaypoint++;
				curTime = 0;
			}
		}

		else if(Timer <0)
			{ 
				MoveOn(moveDirection.normalized * patrolSpeed * Time.deltaTime);
			}	

		if(Vector3.Distance(this.transform.position,target) < 0.5f)
			{
				Targetreached = true;
			}

		else
			{
				Targetreached = false;
			}
	}


	void Spawn (GameObject Points)
	{
		// Waypoints spawnen random auf der Y-Achse, aber in dem vorgegebenen Bereich
		float randomvalueW1 = Random.Range (-spawnValues.y, spawnValues.y);
		float randomvalueW2 = Random.Range (-spawnValues.y, spawnValues.y);
		float randomvalueW3 = Random.Range (-spawnValues.y, spawnValues.y);
		// waypoint w1,w2,w3 spawn auf festgelegten x Koordinaten
		GameObject W1 = Instantiate (Points,new Vector3(7,randomvalueW1,0),Quaternion.identity) as GameObject;
		GameObject W2 = Instantiate (Points,new Vector3(-3,randomvalueW2,0),Quaternion.identity) as GameObject;
		GameObject W3 = Instantiate (Points,new Vector3(-19,randomvalueW3,0),Quaternion.identity) as GameObject;
		//bestimmung des  Arrays
		currentWaypoints [0] = W1;
		currentWaypoints [1] = W2;
		currentWaypoints [2] = W3;

		Wspwaned = true;
		//Waypoints zerstören sich von selbst nach bestimmter Zeit
		Destroy(W1,30.0f);
		Destroy(W2,30.0f);
		Destroy(W3,30.0f);
	}


	void GhostDeath ()
	{
		Timercheck = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().falshlightCheck;
		
		if (!Timercheck && startTimer) 
			{
				startTimer = false;

				//wenn der Timer aufhört, geht der Partikeleffekt aus
				BurnPart.particleSystem.enableEmission = false;
				CottonPart.particleSystem.enableEmission = false;
				FlashlightHit.audio.enabled = false;
			}
		
		if (startTimer) 	
			{
				deathTimer -= Time.deltaTime;
			}
	
		if (deathTimer < 0) 	
			{
				//überschreibt des aktuellen Scores um den betrag des Scores + den scoreValue des Ghosts
				ScoreManager.score += scoreValue;

				//wenn der Geist durch die Taschenlampe zerstört wurde:
				//2D Sprite ausschalten
				myShape.enabled = false;

				//Partikelsystem ausschalten
				BurnPart.particleSystem.enableEmission = false;
				CottonPart.particleSystem.enableEmission = false;
				FlashlightHit.audio.enabled = false;
		
				//Geist zerstören, nach Zeit, damit die Partikeleffekte noch zu Ende gehen
				//Zeit entspricht etwas mehr als der Lebensdauer der Partikel
				Destroy (this.gameObject, 2f);
			}
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


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boundary")
			{
				Destroy(gameObject);
			}
		
		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
			{
				startTimer = false;

				//Ausschalten des Partikeleffekts, wenn man mit der Taschenlampe aus dem Trigger rausgeht
				BurnPart.particleSystem.enableEmission = false;
				CottonPart.particleSystem.enableEmission = false;
				FlashlightHit.audio.enabled = false;
			}
	}


	//SendDamage to Player
	void OnTriggerEnter2D(Collider2D other)
	{

		//nur wenn das 2D Sprite vom Geist an ist, dann....
		if (myShape.enabled == true) 
			{
				if (other.gameObject.tag == Tag)
					other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
					{
						if (other.gameObject.tag == "Player") 
							{
								Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
								FlashlightHit.audio.enabled = false;
							}
					}


		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
			{
				startTimer = true;

				//Wenn der Timer durch die Taschenlampe aktiv ist, läuft auch das Partikelsystem
				/*BurnPart.particleSystem.enableEmission = true;
				CottonPart.particleSystem.enableEmission = true;
				FlashlightHit.audio.enabled = true;

			*/}
		}
	}


	//Funktionsaufruf für die Farb- und Alphawert-Änderung (nur solange man im Trigger drin ist!)
	void OnTriggerStay2D(Collider2D other)
	{
		NewTimer = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().useLight;

		if (NewTimer == true)
		
			{
			if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 

			{
			//	Debug.Log("True");
				startTimer = true;
				ColourChanging ();
				BurnPart.particleSystem.enableEmission = true;
				CottonPart.particleSystem.enableEmission = true;
				FlashlightHit.audio.enabled = true;
			
			}

			}
		if (NewTimer == false)
		{
			startTimer = false;
			BurnPart.particleSystem.enableEmission = false;
			CottonPart.particleSystem.enableEmission = false;
			FlashlightHit.audio.enabled = false;
		}

	}


	//Funktion für Farb- und Alphawert-Änderung während die Taschenlampe auf Geist zielt
	void ColourChanging()
	{
		//Bestimmung der bereits vergangenen Zeit, seitdem die Taschenlampe auf den Geist zielt
		LostTime += Time.deltaTime;
		//Farb- und Alphawert-Änderung durch LERP
		this.gameObject.renderer.material.color = Color.Lerp (ColorOne, ColorTwo, (LostTime)/deathTimer*0.05f);

	}

}