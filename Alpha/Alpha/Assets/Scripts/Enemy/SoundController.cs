using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip spitHit;

	// Use this for initialization
	void Start () {

		audio.PlayOneShot(spitHit, 1.0F);
	}
	
	// Update is called once per frame
	void Update () {


		Destroy (this.gameObject, spitHit.length);
	}
}
