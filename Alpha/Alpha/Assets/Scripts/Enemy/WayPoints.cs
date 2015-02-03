using UnityEngine;
using System.Collections;

public class WayPoints: MonoBehaviour {
	
	      // emptyObjekts = waypoints
	public float patrolSpeed = 3f;       // Geschwindigkeit zwischen den Waypoints
	public bool  loop = true;       // mit hacken setzten kann man das loopen
	public float pauseDuration = 0;   // pause zwischen den waypoints Waypoint
	public GameObject Waypoints;
	private float curTime;
	private GameObject[] currentWaypoints;
	private int Wcounter = 0;
	private bool Wspwaned;
	public bool foundtarget;
	public bool Targetreached;
	public Vector3 spawnValues;

	public GameObject smalGhosts;
	public GameObject Spawn1;
	public GameObject Spawn2;

	public float Timer;

	private Enemy_Controller character; 

	void  Start ()
	{

		currentWaypoints = new GameObject[3];
		character = GetComponent<Enemy_Controller>();
		Spawn (Waypoints);
		gettarget ();
	//	GameObject WP = Instantiate (currentWaypoints[Random.Range(0, currentWaypoints.Length)], transform.position, transform.rotation) as GameObject;
		//GameObject piClone = Instantiate(followers[Random.Range(0, followers.Length)], transform.position, transform.rotation) as GameObject;
	    //Vector3 spawnPosition = new Vector3 (spawnValues.x, randomvalue, spawnValues.z);

	}


	
	void  Update ()
	{

		if(Wspwaned)
		{
			gettarget ();
		}
		if (Timer < 0)
		{
			Timer = 0;
		}
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

			character.MoveOn(moveDirection.normalized * patrolSpeed * Time.deltaTime);
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

	}
}