﻿using UnityEngine;
using System.Collections;

public class WayPoints: MonoBehaviour {
	
	public Transform[] waypoint;        // emptyObjekts = waypoints
	public float patrolSpeed = 3f;       // Geschwindigkeit zwischen den Waypoints
	public bool  loop = true;       // mit hacken setzten kann man das loopen
	//public float dampingLook= 6.0f;          // How slowly to turn
	public float pauseDuration = 0;   // pause zwischen den waypoints Waypoint
	
	private float curTime;
	private int currentWaypoint = 0;
	//GhostSpeed
	public float Speed;
	
/*	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
*/	

	void  Start ()
	{
		

	}
	
	void  Update ()
	{
		{
			float translation = Speed*Time.deltaTime;
			transform.position = new Vector2 (transform.position.x - translation, transform.position.y);
		}

		if(currentWaypoint < waypoint.Length)
		{
			patrol();
		}
		else
		{    
			if(loop)
			{
				currentWaypoint=0;
			} 
		}
	}
	
	void  patrol ()
	{
		
		Vector3 target = waypoint[currentWaypoint].position;
		target.z = transform.position.z; // Keep waypoint at character's height
		Vector3 moveDirection = target - transform.position;
		
		if(moveDirection.magnitude < 0.5f)
		{
			if (curTime == 0)
				curTime = Time.time; // Pause over the Waypoint
			if ((Time.time - curTime) >= pauseDuration)
			{
				currentWaypoint++;
				curTime = 0;
			}
		}
		else
		{        

			//var rotation= Quaternion.LookRotation(target - transform.position);
			//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
			//(moveDirection.normalized * patrolSpeed * Time.deltaTime);
		}  
	}
}