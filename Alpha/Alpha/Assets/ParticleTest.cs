using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {

	public GameObject BGParticle;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnDestroy () {

	
	Instantiate (BGParticle, transform.position, transform.rotation);
		Debug.Log("kaputt");
	}
}
