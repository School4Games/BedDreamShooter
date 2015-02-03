using UnityEngine;
using System.Collections;

public class BigGhostController : MonoBehaviour 
{
	
	private float Speed = 0.0f;
	public Vector2 movementDirection = new Vector2(-1,0);

	//Health and Death
	public float deathTimer;
	private bool startTimer;
	private bool Timercheck;
	public int scoreValue;
	public int damageValue = 1;
	public string Tag;

	//WayPoints
	public float patrolSpeed = 3f;       // Geschwindigkeit zwischen den Waypoints
	public float pauseDuration = 0;   // pause zwischen den waypoints Waypoint
	public GameObject Waypoints;
	private float curTime;
	private GameObject[] currentWaypoints;
	private int Wcounter = 0;
	private bool Wspwaned;
	private bool foundtarget;
	private bool Targetreached;
	public Vector3 spawnValues;
	public float Timer;

	//SmallGhost Spawn
	public GameObject smalGhosts;
	public GameObject Spawn1;
	public GameObject Spawn2;

	//private Enemy_Controller character; 

	// Use this for initialization
	void Start () 
	{
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
		if (Timer <= 10) {
			Timer -= Time.deltaTime;
		}
		
		Vector3 target = currentWaypoints [Wcounter].transform.position;
		patrol (target);
		
		if (Targetreached && Timer <= 0) 
		{
			Instantiate (smalGhosts, Spawn1.transform.position,Quaternion.identity);
			Instantiate (smalGhosts, Spawn2.transform.position,Quaternion.identity);
			Wcounter++;
			Timer = 3;
		}
		
	}
	
	void  patrol (Vector3 target)
	{
		
		
		target.z = transform.position.z; // Keep waypoint at character's height
		Vector3 moveDirection = target - transform.position;
		
		if(moveDirection.magnitude < 0.5f)
		{
			if (curTime == 0)
				curTime = Time.time; // Pause over the Waypoint
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
		}else
		{
			Targetreached = false;
		}
	}
	
	void Spawn (GameObject Points)
	{

		float randomvalueW1 = Random.Range (-spawnValues.y, spawnValues.y);
		float randomvalueW2 = Random.Range (-spawnValues.y, spawnValues.y);
		float randomvalueW3 = Random.Range (-spawnValues.y, spawnValues.y);
		GameObject W1 = Instantiate (Points,new Vector3(7,randomvalueW1,0),Quaternion.identity) as GameObject;
		GameObject W2 = Instantiate (Points,new Vector3(-3,randomvalueW2,0),Quaternion.identity) as GameObject;
		GameObject W3 = Instantiate (Points,new Vector3(-19,randomvalueW3,0),Quaternion.identity) as GameObject;
		currentWaypoints [0] = W1;
		currentWaypoints [1] = W2;
		currentWaypoints [2] = W3;
		Wspwaned = true;
		Destroy(W1,25.0f);
		Destroy(W2,25.0f);
		Destroy(W3,25.0f);
	}

	void GhostDeath ()
	{
		
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
			ScoreManager.score += scoreValue;
			Destroy (this.gameObject);
		}
	}
	
	public void Move()
		
	{
		float translation = Speed*Time.deltaTime;
		
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

		if (other.gameObject.tag == Tag)
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

}