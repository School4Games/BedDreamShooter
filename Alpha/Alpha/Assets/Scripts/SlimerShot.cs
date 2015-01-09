using UnityEngine;
using System.Collections;

public class SlimerShot : MonoBehaviour 
{

	public GameObject shot;
	public float startWait;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if  (Time.deltaTime > nextFire)
		{
			nextFire = Time.deltaTime + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
	

}

