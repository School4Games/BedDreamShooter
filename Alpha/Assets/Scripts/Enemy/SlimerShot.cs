using UnityEngine;
using System.Collections;

public class SlimerShot : MonoBehaviour 
{

	public GameObject shot;
	public Transform shotSpawn;
	public float Timer;
	public float ResetTimer;
	// Use this for initialization
	void Start () 
	{
		ResetTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Timer <= 0)
			{
				Fire ();
				Timer = ResetTimer;
			}
		else
			{
				Timer -= Time.deltaTime;
			}

	}
	void Fire()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
	}

}

