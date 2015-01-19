using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour 
{
	public GameObject spaceThing;
	public Transform shotSpaw;
	public int timer;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		timer = timer -1;
		if (timer == -6) 
		{
			timer = -1;
		}

		if (timer == 0) 
		{
			Spawn ();
		}
	}
	void Spawn()
	{

		Instantiate(spaceThing, shotSpaw.position, shotSpaw.rotation);
	}

}
