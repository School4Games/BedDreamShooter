using UnityEngine;
using System.Collections;

public class PillowParticleDestroy : MonoBehaviour {

	private int delay = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Destroy (this.gameObject, delay);

	}
}
