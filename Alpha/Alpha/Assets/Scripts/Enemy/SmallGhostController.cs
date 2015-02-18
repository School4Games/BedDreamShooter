using UnityEngine;
using System.Collections;

public class SmallGhostController : MonoBehaviour 
{

	public float damageValue = 1;
	public string Tag; 
	public float deathTimer;		
	private bool startTimer;
	private bool Timercheck;
	public GameObject SoundObject;
	public int scoreValue;
	public int killScoreValue;

	//Partikeleffekt
	public GameObject BurnPart;
	public GameObject CottonPart;
	public Color ColorOne;
	public Color ColorTwo;
	private float LostTime = 0;
	private SpriteRenderer myShape;





	//Finder
	private Vector3 characterPos; 	//characterPos= die position vom smallGhost,
	private Vector3 playerPos;		// playerPos= die aktuelle position vom Player
	private GameObject player;
	private Vector3 movementDir;	//movementDir= der richtungs Vector 
	public float speed;
	// Use this for initialization

	void Start () 
	{
		Finder ();
		//Komponente vom 2D Sprite
		myShape = GetComponent<SpriteRenderer> ();
	}

	void Update()

	{
		//Timercheck = GameObject.FindGameObjectWithTag ("Light").GetComponent<hide_unhide> ().falshlightCheck;
		Death();
	}
	void Finder()
	{
		//Find player	
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

				//wenn der Timer aufhört, geht der Partikeleffekt aus
				BurnPart.particleSystem.enableEmission = false;
				CottonPart.particleSystem.enableEmission = false;
			}
		if (startTimer) 	
			{
				deathTimer -= Time.deltaTime;
			}
		if (deathTimer < 0)
			{
				ScoreManager.score += scoreValue;

				//wenn der Geist durch die Taschenlampe zerstört wurde:
				//2D Sprite ausschalten
				myShape.enabled = false;
				//Partikelsystem ausschalten
				BurnPart.particleSystem.enableEmission = false;
				CottonPart.particleSystem.enableEmission = false;
				//Geist zerstören, nach Zeit, damit die Partikeleffekte noch zu Ende gehen
				//Zeit entspricht etwas mehr als der Lebensdauer der Partikel
				Destroy (this.gameObject, 2.0f);

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

				//Ausschalten des Partikeleffekts, wenn man mit der Taschenlampe aus dem Trigger rausgeht
				BurnPart.particleSystem.enableEmission = false;
				CottonPart.particleSystem.enableEmission = false;
			}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{

		//nur wenn das 2D Sprite vom Geist an ist, dann....
		if (myShape.enabled == true) 
			{
				if (other.gameObject.tag == Tag)
					other.gameObject.SendMessage ("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
				
				if (other.gameObject.tag == "Player") 
					{
						ScoreManager.score += killScoreValue;
						Destroy (this.gameObject); // gameObject an welchem das script dranhängt (pillow)
						Instantiate (SoundObject, transform.position, transform.rotation);
					}
			}
		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
			{
				startTimer = true;

				//Wenn der Timer durch die Taschenlampe aktiv ist, läuft auch das Partikelsystem
				BurnPart.particleSystem.enableEmission = true;
				CottonPart.particleSystem.enableEmission = true;
			}
		
	}

	//Funktionsaufruf für die Farb- und Alphawert-Änderung (nur solange man im Trigger drin ist!)
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Light" && this.gameObject.tag == "BGhost") 
			{
				ColourChanging ();
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

